using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Window : ItemBase
{
    [SerializeField] public CheckScrpitBase script;
    [SerializeField] public bool isClose = false;
    [SerializeField] public Sprite changeImage;
    [SerializeField] public Sprite nowImage;
    [SerializeField] private PlaySound soundPlay;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nowImage = spriteRenderer.sprite;
    }

    public override void UseItem()
    {
        if (isClose)
            return;

        this.spriteRenderer.sprite = changeImage;
        isClose = true;
        script.Clear();
        soundPlay.Play();
    }
}
