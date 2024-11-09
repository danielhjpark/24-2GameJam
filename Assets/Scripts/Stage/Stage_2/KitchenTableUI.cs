using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenTableUI : MonoBehaviour
{
    [SerializeField] public CheckScrpitBase check;
    [SerializeField] private bool isClear = false;
    [SerializeField] public bool[] bools = new bool[3];

    private void Awake()
    {
        bools[0] = false;
        bools[1] = false;
        bools[2] = false;
    }

    private void Update()
    {
        if (isClear)
        {
            return;
        }

        if (bools[0] && bools[1] && bools[2])
        {
            isClear = true;
            check.Clear();
            // 애니메이션 재생이 되든 하셈
        }
    }
}
