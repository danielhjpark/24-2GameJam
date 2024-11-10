using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeNote : MonoBehaviour
{
    [SerializeField]
    private Sprite BeginImg;
    [SerializeField]
    private Sprite AfterImg;
    [SerializeField]
    private GameObject PopUpImg;

    [SerializeField]
    public bool ClearTalk = false;

    private void Awake()
    {
        //this.gameObject.GetComponent<SpriteRenderer>().sprite = BeginImg;
    }
    private void Update()
    {
        if(ClearTalk)
        {
            PopUpImg.gameObject.GetComponent<Image>().sprite = AfterImg;
        }    
    }
}
