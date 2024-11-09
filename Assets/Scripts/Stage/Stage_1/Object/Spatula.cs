using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spatula : ItemBase
{
    [SerializeField] public KitchenTable kitchenTable;
    [SerializeField] public int ItemNum; // 0 knife, 1 Flipper, 2 Spatula

    public override void UseItem()
    {
        kitchenTable.GetItem(ItemNum);
        Destroy(this.gameObject);
    }
}
