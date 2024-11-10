using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;//Text field�� ����� �� �ֵ��� �ϴ� header
using UnityEngine.SceneManagement;

[System.Serializable] //���� ���� class�� ������ �� �ֵ��� ����. 
public class Dialogue2
{
    [TextArea]//���� ���� ���� �� �� �� �ְ� ����
    public string dialogue;
    public string name;
    public Sprite cg;

}
public class EndingChat : MonoBehaviour
{
    [SerializeField]
    private Text txt_Dialogue; // �ؽ�Ʈ�� �����ϱ� ���� ����
    [SerializeField]
    private Text txt_NameDialogue;
    [SerializeField]
    private GameObject imgTextPanel;
    [SerializeField]
    private GameObject imgNamePanel;
    [SerializeField]
    private string NextSceneName;

    [SerializeField]
    public Image portrainImg;

    [SerializeField]
    private bool firstclick = false;

    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    private int count = 0; //��簡 �󸶳� ����ƴ��� �˷��� ����

    [SerializeField] private Dialogue1[] dialogue;

    [SerializeField]
    public CameraManager cameraManager;


    public void ShowDialogue()
    {
        ONOFF(true); //��ȭ�� ���۵�
        //GameManager.Instance.Player.isMoving = false;

        count = 0;
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
    }

    private void ONOFF(bool _flag)
    {
        imgTextPanel.gameObject.SetActive(_flag);
        imgNamePanel.gameObject.SetActive(_flag);
        txt_NameDialogue.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        portrainImg.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
        txt_Dialogue.text = dialogue[count].dialogue;
        txt_NameDialogue.text = dialogue[count].name;
        portrainImg.sprite = dialogue[count].cg;
        count++;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && firstclick == false)
        {
            ShowDialogue();
            firstclick = true;
        }
        //spacebar ���� ������ ��簡 ����ǵ���. 
        if (isDialogue) //Ȱ��ȭ�� �Ǿ��� ���� ��簡 ����ǵ���
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //��ȭ�� ���� �˾ƾ���.
                if (count < dialogue.Length)
                {
                    NextDialogue(); //���� ��簡 �����
                }
                else
                {
                    ONOFF(false); //��簡 ����
                    SceneManager.LoadScene(NextSceneName);
                    //cameraManager.sceneDone = false;
                    //GameManager.Instance.Player.isMoving = true;
                    //GameManager.Instance.Player.gameObject.SetActive(true);
                }
            }
        }
    }
}