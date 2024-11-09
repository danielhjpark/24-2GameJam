using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour
{
    [SerializeField]
    public bool check1 = false; //스테이지 클리어 조건 1
    [SerializeField]
    public bool check2 = false; //스테이지 클리어 조건 2
    [SerializeField]
    public bool check3 = false; //스테이지 클리어 조건 3

    [SerializeField]
    private CameraManager cameraManager;
    public void Check(int num)
    {
        switch (num)
        {
            case 1:
                check1 = true;
                break;

            case 2:
                check2 = true;
                break;

            case 3:
                check3 = true;
                break;
        }

    }
    private void Update()
    {
        if (check1 && check2 && check3 && cameraManager.sceneDone == false)
        {
            cameraManager.stageClear = true;
        }
    }
}
