using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTable : ItemBase
{
    [SerializeField] public GameObject keyItem1;
    [SerializeField] public GameObject keyItem2;
    [SerializeField] public GameObject keyItem3;

    [SerializeField] public PopUpUI popup;

    public void GetItem(int num)
    {
        switch (num)
        {
            case 1:
                keyItem1.SetActive(true);
                break;
            case 2:
                keyItem2.SetActive(true);
                break;
            case 3:
                keyItem3.SetActive(true);
                break;
        }
    }

    public override void UseItem()
    {
        popup.PopUp();
    }
}
