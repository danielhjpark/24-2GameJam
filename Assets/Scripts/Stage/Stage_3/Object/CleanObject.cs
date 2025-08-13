using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanObject: ItemBase
{
    [SerializeField] public int tidyNum;
    [SerializeField] public Stage3SubManager script;
    [SerializeField] public bool isClean = false;
    [SerializeField] public Sprite changeImage;
    [SerializeField] public Sprite nowImage;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private PlaySound soundPlay;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        nowImage = spriteRenderer.sprite;
    }

    public override void UseItem()
    {
        if (isClean)
            return;

        this.spriteRenderer.sprite = changeImage;
        isClean = true;
        script.TidyUP(tidyNum);
        soundPlay.Play();
    }
}
