using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3SubManager : MonoBehaviour
{
    [Header("정리")]
    [SerializeField] public bool[] bools = new bool[3];
    // 0 문서, 1 침대, 2 빗자루

    [SerializeField] public StageManager stageManager;
    [SerializeField] public GameObject lastObject;

    [SerializeField] CameraManager cameraManager;

    [SerializeField]
    private StageChat stageChat;

    [SerializeField]
    private bool GoDialog = false;

    private void Start()
    {
        bools[0] = false;
        bools[1] = false;
        bools[2] = false;
    }

    // 정리정돈
    public void TidyUP(int num)
    {
        switch (num)
        {
            case 1:
                bools[0] = true;
                break;
            case 2:
                bools[1] = true;
                break;
            case 3:
                bools[2] = true;
                break;
        }

        if (bools[0] && bools[1] && bools[2])
        {
            stageManager.Check(1);
        }
    }

    private void Update()
    {
        if (lastObject == null)
            return;
        if (stageManager.check1&& stageManager.check2 && GoDialog == false)
        {
            GoDialog = true;
            cameraManager.stageClear = true;
            stageChat.ShowDialogue();
        }

        if (lastObject.activeSelf)
            return;

        if(cameraManager.sceneDone)
        {
            lastObject.SetActive(true);
        }
    }
}
