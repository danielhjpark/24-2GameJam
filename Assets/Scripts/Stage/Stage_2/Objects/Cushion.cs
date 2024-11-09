using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cushion : ItemBase
{
    [SerializeField] public CheckScrpitBase script;
    [SerializeField] public GameObject hideObject;
    [SerializeField] public GameObject moveDirection;

    public override void UseItem()
    {
        if (moveDirection == null)
            return;

        hideObject.SetActive(true);
        this.transform.position = moveDirection.transform.position;
        Destroy(moveDirection);
        script.Clear();
        Debug.Log("¹æ¼® ¿Å±è");
    }
}
