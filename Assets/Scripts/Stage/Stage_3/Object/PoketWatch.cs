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
        // 게임 클리어
        Debug.Log("게임 클리어");
        _cameraManager.stageClear = true;
        stageChat.ShowDialogue();
    }
}
