using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class TalkManager : MonoBehaviour
{
    [SerializeField]
    private Script[] nowDialogue;

    [SerializeField]
    private Text txt_Dialogue; // �ؽ�Ʈ�� �����ϱ� ���� ����
    [SerializeField]
    private Text txt_NameDialogue;
    [SerializeField]
    private GameObject imgTextPanel;
    [SerializeField]
    private GameObject imgNamePanel;


    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    private int count = 0; //��簡 �󸶳� ����ƴ��� �˷��� ����


    private void Awake()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    // Update is called once per frame
    void Update()
    {
        if (imgNamePanel == null)
            return;

        if (isDialogue) //Ȱ��ȭ�� �Ǿ��� ���� ��簡 ����ǵ���
        {
            if (Input.anyKeyDown) //�����̽��ٷ� �����ؾ���.
            {
                //��ȭ�� ���� �˾ƾ���.
                if (count < nowDialogue.Length)
                {
                    NextDialogue(); //���� ��簡 �����
                }
                else
                {
                    ONOFF(false); //��簡 ����
                    GameManager.Instance.Player.isMoving = true;
                }

            }
        }
    }

    private void FixedUpdate()
    {
        // ���̾�α� �־��ֱ�
        if(GameManager.Instance.Player.target && nowDialogue == null)
        {
            GameObject target = GameManager.Instance.Player.target;

            if(target.GetComponent<Dialogue>() != null )
            {
                Dialogue dialogue = target.GetComponent<Dialogue>();

                nowDialogue = dialogue.dialogue;
            }
        }

        if(!GameManager.Instance.Player.target && nowDialogue != null)
        {
            nowDialogue = null;
        }
    }

    public void ShowDialogue()
    {
        if (nowDialogue == null)
            return;
        GameManager.Instance.Player.isMoving = false;
        ONOFF(true); //��ȭ�� ���۵�
        count = 0;
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
    }

    private void ONOFF(bool _flag)
    {


        txt_Dialogue.gameObject.SetActive(_flag);
        txt_NameDialogue.gameObject.SetActive(_flag);
        imgTextPanel.gameObject.SetActive(_flag);
        imgNamePanel.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
        txt_Dialogue.text = nowDialogue[count].dialogue;
        txt_NameDialogue.text = nowDialogue[count].name;

        count++; //���� ���� cg�� �������� 
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("���ε�");
        // ���� �ε�� ������ TalkText�� ã�Ƽ� �Ҵ�
        GameObject talkTextObject = GameObject.Find("Canvas/Talk/TalkPanel/TalkText");
        GameObject nameTextObject = GameObject.Find("Canvas/Talk/NamePanel/NameText");
        GameObject talkPanelObject = GameObject.Find("Canvas/Talk/TalkPanel");
        GameObject namePanelObject = GameObject.Find("Canvas/Talk/NamePanel");

        if (talkTextObject != null)
        {
            txt_Dialogue = talkTextObject.GetComponent<Text>();
        }
        if (nameTextObject != null)
        {
            txt_NameDialogue = nameTextObject.GetComponent<Text>();
        }
        if (talkPanelObject != null)
        {
            imgTextPanel = talkPanelObject;
        }
        if (namePanelObject != null)
        {
            imgNamePanel = namePanelObject;
        }
    }
}
