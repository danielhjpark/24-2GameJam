using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field�� ����� �� �ֵ��� �ϴ� header
using UnityEngine.SceneManagement;

[System.Serializable] //���� ���� class�� ������ �� �ֵ��� ����. 
public class _Dialogue
{
    [TextArea]//���� ���� ���� �� �� �� �ְ� ����
    public string dialogue;
    public string name;
    public Sprite cg;

}
public class TutorialChat : MonoBehaviour
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
    public Image portrainImg;

    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    private int count = 0; //��簡 �󸶳� ����ƴ��� �˷��� ����

    [SerializeField] private _Dialogue[] dialogue;

    [SerializeField]
    private GameObject Book;
    [SerializeField]
    private GameObject OpenBook;

    [SerializeField]
    private bool isChenge = false;

    [SerializeField]
    private string NextScene = "Stage_1";

    private void Awake()
    {
        ShowDialogue();
    }

    public void ShowDialogue()
    {
        ONOFF(true); //��ȭ�� ���۵�
        count = 0;
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
    }

    private void ONOFF(bool _flag)
    {
        imgTextPanel.gameObject.SetActive(_flag);
        imgNamePanel.gameObject.SetActive(_flag);
        txt_NameDialogue.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
        txt_Dialogue.text = dialogue[count].dialogue;
        portrainImg.sprite = dialogue[count].cg;
        txt_NameDialogue.text = dialogue[count].name;
        count++; //���� ���� cg�� �������� 
        if(count == 5)//�ش� ���̾�α��� �� 
        {
            Book.gameObject.SetActive(false);
            OpenBook.gameObject.SetActive(true);
            //���� ��� �ؾ���.!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }

    // Update is called once per frame
    void Update()
    {
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
                    StartCoroutine(ReadBook());
                }
            }
        }
    }

    IEnumerator ReadBook()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(NextScene);
    }
}