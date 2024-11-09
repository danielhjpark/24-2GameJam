using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScrpitBase : MonoBehaviour
{
    [SerializeField] private StageManager stage;
    [SerializeField] private int clearNum;
    [SerializeField] public string nextStage;

    public void Clear()
    {
        stage.Check(clearNum);
    }
}
