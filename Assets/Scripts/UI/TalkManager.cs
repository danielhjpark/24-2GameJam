using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TalkManager : MonoBehaviour
{
    [SerializeField]
    private Script[] nowDialogue;

    [SerializeField]
    private Text txt_Dialogue; // 텍스트를 제어하기 위한 변수
    [SerializeField]
    private Text txt_NameDialogue;
    [SerializeField]
    private Image imgTextPanel;
    [SerializeField]
    private Image imgNamePanel;


    private bool isDialogue = false; //대화가 진행중인지 알려줄 변수
    private int count = 0; //대사가 얼마나 진행됐는지 알려줄 변수

    private void FixedUpdate()
    {
        // 다이얼로그 넣어주기
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

        ONOFF(true); //대화가 시작됨
        count = 0;
        NextDialogue(); //호출되자마자 대사가 진행될 수 있도록 
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
        //첫번째 대사와 첫번째 cg부터 계속 다음 cg로 진행되면서 화면에 보이게 된다. 
        txt_Dialogue.text = nowDialogue[count].dialogue;
        txt_NameDialogue.text = nowDialogue[count].name;

        count++; //다음 대사와 cg가 나오도록 
    }


    // Update is called once per frame
    void Update()
    {
        //spacebar 누를 때마다 대사가 진행되도록. 
        if (isDialogue) //활성화가 되었을 때만 대사가 진행되도록
        {
            if (Input.anyKeyDown)
            {
                //대화의 끝을 알아야함.
                if (count < nowDialogue.Length) NextDialogue(); //다음 대사가 진행됨
                else ONOFF(false); //대사가 끝남

            }
        }

    }
}
