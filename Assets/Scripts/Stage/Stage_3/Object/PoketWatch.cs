using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoketWatch : ItemBase
{
    [SerializeField]
    private CameraManager _cameraManager;

    public override void UseItem()
    {
        // 게임 클리어
        Destroy(this.gameObject);
        Debug.Log("게임 클리어");
    }
}
