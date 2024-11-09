using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : ItemBase
{
    [SerializeField] public KitchenTable keyTable;
    [SerializeField] public int ItemNum; // 0 HourHand 1 SawTooth_1 2 SawTooth_2

    public override void UseItem()
    {
        keyTable.GetItem(ItemNum);
        Destroy(this.gameObject);
    }
}
