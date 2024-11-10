using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaneNote : MonoBehaviour
{
    [SerializeField]
    private Sprite BeforeImg;
    [SerializeField]
    private Sprite AfterImg;

    [SerializeField]
    public bool ClearTalk = false;

    private void Update()
    {
        if(ClearTalk)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = AfterImg;
        }    
    }
}
