
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class RecordPlayer : MonoBehaviour
{
    [SerializeField] public GameObject Jazz_record;
    [SerializeField] public GameObject Classic_record;
    [SerializeField] public GameObject Tengo_record;

    [SerializeField] public bool canGet = false;
    [SerializeField] public GameObject popUp_panel;
    [SerializeField] public PopUpUI popUpUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canGet = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canGet)
        {
            if (Input.GetKey(KeyCode.E) && !popUp_panel.activeSelf)
            {
                Debug.Log("Get");
                popUpUI.PopUp();
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

    public void GetRecord(int num)
    {
        switch (num)
        {
            case 0:
                Jazz_record.SetActive(true);
                break;

            case 1:
                Classic_record.SetActive(true);
                break;

            case 2:
                Tengo_record.SetActive(true);
                break;
        }
    }
}
