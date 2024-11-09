using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenPanel : MonoBehaviour
{
    [SerializeField] KitchenTableUI kitchenTableUI;
    [SerializeField] public string needToolname;
    [SerializeField] public int nowPanelNum;

    private void Update()
    {
        if (this.gameObject.GetComponentInChildren<DragAndDrop>() != null)
        {
            if (this.gameObject.GetComponentInChildren<DragAndDrop>().name == needToolname)
            {
                kitchenTableUI.bools[nowPanelNum] = true;
            }
        }
    }
}
