using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoketWatch : ItemBase
{

    [SerializeField]
    private StageChat stageChat;

    public override void UseItem()
    {
        // ���� Ŭ����
        Debug.Log("���� Ŭ����");
        stageChat.ShowDialogue();
    }
}
