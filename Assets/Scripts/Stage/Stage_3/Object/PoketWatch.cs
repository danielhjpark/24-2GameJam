using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoketWatch : ItemBase
{
    [SerializeField]
    private CameraManager _cameraManager;

    public override void UseItem()
    {
        // ���� Ŭ����
        Destroy(this.gameObject);
        Debug.Log("���� Ŭ����");
    }
}
