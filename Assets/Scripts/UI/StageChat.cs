using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Text field를 사용할 수 있도록 하는 header
using UnityEngine.SceneManagement;

[System.Serializable] //직접 만든 class에 접근할 수 있도록 해줌. 
public class Dialogue1
{
    [TextArea]//한줄 말고 여러 줄 쓸 수 있게 해줌
    public string dialogue;
    public string name;
    public Sprite cg;
    public Sprite leftcg;
}
public class StageChat : MonoBehaviour
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
    private string NextSceneName;
    [SerializeField]
    private GameObject bindPanel;

    [SerializeField]
    public Image portrainImg;
    [SerializeField]
    public Image leftinImg;
    [SerializeField]
    public Sprite nullImage;
    [SerializeField]
    public GameObject ImagePanel;

    [SerializeField]
    private ChangeNote changeNote;

    [SerializeField]
    private bool canTravel = false;

    private bool isDialogue = false; //대화가 진행중인지 알려줄 변수
    private int count = 0; //대사가 얼마나 진행됐는지 알려줄 변수

    [SerializeField] private Dialogue1[] dialogue;

    [SerializeField]
    public CameraManager cameraManager;

    [SerializeField]
    public SoundManager soundManager;

    public void ShowDialogue()
    {
        ONOFF(true); //대화가 시작됨
        GameManager.Instance.playMode = "color";
        GameManager.Instance.Player.isMoving = false;
        soundManager.ChangeSound();
        
        count = 0;
        NextDialogue(); //호출되자마자 대사가 진행될 수 있도록 
    }

    private void ONOFF(bool _flag)
    {
        imgTextPanel.gameObject.SetActive(_flag);
        imgNamePanel.gameObject.SetActive(_flag);
        txt_NameDialogue.gameObject.SetActive(_flag);
        portrainImg.gameObject.SetActive(_flag);
        leftinImg.gameObject.SetActive(_flag);
        txt_Dialogue.gameObject.SetActive(_flag);
        bindPanel.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //첫번째 대사와 첫번째 cg부터 계속 다음 cg로 진행되면서 화면에 보이게 된다. 
        txt_Dialogue.text = dialogue[count].dialogue;
        txt_NameDialogue.text = dialogue[count].name;
        leftinImg.sprite = dialogue[count].leftcg;
        portrainImg.sprite = dialogue[count].cg;

        count++;

    }

    // Update is called once per frame
    void Update()
    {
        if(cameraManager.stageClear)
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
                        cameraManager.sceneDone = true;
                        GameManager.Instance.playMode = "black";
                        GameManager.Instance.Player.isMoving = true;
                        GameManager.Instance.Player.gameObject.SetActive(true);
                        soundManager.ReturnSound();
                        Debug.Log("대사 끝");
                        changeNote.ClearTalk = true;
                        canTravel = true;
                    }
                }
            }
        }
        if(canTravel)
        {
            if(Input.GetKeyDown(KeyCode.V))
            {
                changeNote.ClearTalk = false;
                SceneManager.LoadScene(NextSceneName);
            }
        }
    }
}