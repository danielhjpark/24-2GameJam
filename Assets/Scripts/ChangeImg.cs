using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeImg : MonoBehaviour
{
    [SerializeField]
    private Sprite ColorSprite;
    [SerializeField]
    private Sprite BlackSprite;

    private void Update()
    {
        if(GameManager.Instance.playMode == "black")
        {
            BlackImage();
        }
        else if(GameManager.Instance.playMode == "color")
        {
            ColorImage();
        }
    }

    private void BlackImage()
    {
        Debug.Log("ChangeBlack");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = BlackSprite;
    }

    private void ColorImage()
    {
        Debug.Log("ChangeColor");
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ColorSprite;
    }
}
