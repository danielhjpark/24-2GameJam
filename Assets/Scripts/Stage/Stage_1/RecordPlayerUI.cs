using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerUI : MonoBehaviour
{
    [SerializeField] public CheckScript check;
    [SerializeField] private bool isClear = false;
    [SerializeField] public GameObject panel;
    [SerializeField] public GameObject child;
    [SerializeField] public PopUpUI popUpUI;

    private void Update()
    {
        if (isClear)
        {
            return;
        }

        if(this.gameObject.GetComponentInChildren<DragAndDrop>() != null)
        {
            if (this.gameObject.GetComponentInChildren<DragAndDrop>().name == "Jazz")
            {
                isClear = true;
                check.Clear();
                // �ִϸ��̼� ����� �ǵ� �ϼ�
                popUpUI.PopUp();
            }
        }
    }
}
