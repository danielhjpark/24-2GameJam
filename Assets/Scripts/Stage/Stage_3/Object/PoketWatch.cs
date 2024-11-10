using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PoketWatch : ItemBase
{
    [SerializeField]
    private CameraManager _cameraManager;
    [SerializeField]
    private string NextSceneName = "Ending";

    public override void UseItem()
    {
        // 게임 클리어
        Destroy(this.gameObject);
        SceneManager.LoadScene(NextSceneName);

        Debug.Log("게임 클리어");
    }
}
