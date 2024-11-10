using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field를 사용할 수 있도록 하는 header
using UnityEngine.SceneManagement;

[System.Serializable] //직접 만든 class에 접근할 수 있도록 해줌. 
public class _Dialogue
{
    [TextArea]//한줄 말고 여러 줄 쓸 수 있게 해줌
    public string dialogue;
    public string name;
    public Sprite cg;

}
public class TutorialChat : MonoBehaviour
{
    [SerializeField]
    private Text txt_Dialogue; // 텍스트를 제어하기 위한 변수
    [SerializeField]
    private Text txt_NameDialogue;
    [SerializeField]
    private GameObject imgTextPanel;
    [SerializeField]
    private GameObject imgNamePanel;
    [SerializeField]
    public Image portrainImg;

    private bool isDialogue = false; //대화가 진행중인지 알려줄 변수
    private int count = 0; //대사가 얼마나 진행됐는지 알려줄 변수

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
        ONOFF(true); //대화가 시작됨
        count = 0;
        NextDialogue(); //호출되자마자 대사가 진행될 수 있도록 
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
        //첫번째 대사와 첫번째 cg부터 계속 다음 cg로 진행되면서 화면에 보이게 된다. 
        txt_Dialogue.text = dialogue[count].dialogue;
        portrainImg.sprite = dialogue[count].cg;
        txt_NameDialogue.text = dialogue[count].name;
        count++; //다음 대사와 cg가 나오도록 
        if(count == 5)//해당 다이얼로그일 때 
        {
            Book.gameObject.SetActive(false);
            OpenBook.gameObject.SetActive(true);
            //사운드 재생 해야함.!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spacebar 누를 때마다 대사가 진행되도록. 
        if (isDialogue) //활성화가 되었을 때만 대사가 진행되도록
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //대화의 끝을 알아야함.
                if (count < dialogue.Length)
                {
                    NextDialogue(); //다음 대사가 진행됨
                }
                else
                {
                    ONOFF(false); //대사가 끝남
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