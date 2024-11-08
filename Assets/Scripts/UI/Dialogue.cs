using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Script
{
    [TextArea]
    public string dialogue;
    public string name;

}

public class Dialogue : MonoBehaviour
{
    [SerializeField]
    public Script[] dialogue;
}
