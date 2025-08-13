using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    [SerializeField] private Stage1Manager stage1;
    [SerializeField] private int clearNum;

    public void Clear()
    {
        stage1.Check(clearNum);
    }
}
