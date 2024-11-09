using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoketWatch : ItemBase
{
    [SerializeField]
    private CameraManager _cameraManager;

    [SerializeField]
    private StageChat stageChat;

    public override void UseItem()
    {
        // ���� Ŭ����
        Debug.Log("���� Ŭ����");
        _cameraManager.stageClear = true;
        stageChat.ShowDialogue();
    }
}
