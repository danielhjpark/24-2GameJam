using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    [TextArea]
    public string dialogue;
    public string name;
}
public class TalkManager : MonoBehaviour
{


    [SerializeField]
    private Text txt_Dialogue; // �ؽ�Ʈ�� �����ϱ� ���� ����
    [SerializeField]
    private Text txt_NameDialogue;


    private bool isDialogue = false; //��ȭ�� ���������� �˷��� ����
    private int count = 0; //��簡 �󸶳� ����ƴ��� �˷��� ����

    [SerializeField]
    private Dialogue[] dialogue;

    [SerializeField]
    private Dialogue[] name;


    public void ShowDialogue()
    {
        ONOFF(true); //��ȭ�� ���۵�
        count = 0;
        NextDialogue(); //ȣ����ڸ��� ��簡 ����� �� �ֵ��� 
    }

    private void ONOFF(bool _flag)
    {


        txt_Dialogue.gameObject.SetActive(_flag);
        txt_NameDialogue.gameObject.SetActive(_flag);
        isDialogue = _flag;
    }

    private void NextDialogue()
    {
        //ù��° ���� ù��° cg���� ��� ���� cg�� ����Ǹ鼭 ȭ�鿡 ���̰� �ȴ�. 
        txt_Dialogue.text = dialogue[count].dialogue;
        txt_NameDialogue.text = dialogue[count].name;

        count++; //���� ���� cg�� �������� 

    }


    // Update is called once per frame
    void Update()
    {
        //spacebar ���� ������ ��簡 ����ǵ���. 
        if (isDialogue) //Ȱ��ȭ�� �Ǿ��� ���� ��簡 ����ǵ���
        {
            if (Input.anyKeyDown)
            {
                //��ȭ�� ���� �˾ƾ���.
                if (count < dialogue.Length) NextDialogue(); //���� ��簡 �����
                else ONOFF(false); //��簡 ����

            }
        }

    }
}
