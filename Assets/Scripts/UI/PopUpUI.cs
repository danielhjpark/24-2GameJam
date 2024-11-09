using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpUI : MonoBehaviour
{
    [SerializeField]
    public GameObject sprite;

    private void Update()
    {
        if(sprite.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PopUp();
        }
    }

    public void PopUp()
    {
        sprite.SetActive(!sprite.activeSelf);
        if(sprite.activeSelf )
        {
            GameManager.Instance.Player.isMoving = false;
        }
        else if(!sprite.activeSelf )
        {
            GameManager.Instance.Player.isMoving = true;
        }
    }
}
