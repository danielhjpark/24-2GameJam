using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3SubManager : MonoBehaviour
{
    [Header("����")]
    [SerializeField] public bool[] bools = new bool[3];
    // 0 ����, 1 ħ��, 2 ���ڷ�

    [SerializeField] public StageManager stageManager;
    [SerializeField] public GameObject lastObject;

    private void Start()
    {
        bools[0] = false;
        bools[1] = false;
        bools[2] = false;
    }

    // ��������
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
        if (lastObject.activeSelf)
            return;

        if(stageManager.check1 && stageManager.check2)
        {
            lastObject.SetActive(true);
        }
    }
}
