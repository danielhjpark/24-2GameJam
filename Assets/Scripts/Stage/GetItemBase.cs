using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemBase : MonoBehaviour
{

    [SerializeField] public bool canGet = false;

    [SerializeField]
    private StageChat stageChat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canGet = true;
        }
    }

    private void Update()
    {
        if (canGet)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                stageChat.ShowDialogue();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canGet = false;
        }
    }
}
