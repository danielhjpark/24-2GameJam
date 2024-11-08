using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] public RecordPlayer RCplayer;
    [SerializeField] public int recordNum; // 0 Jazz, 1 Classic, 2 Tengo
    [SerializeField] public bool canGet = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canGet = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(canGet)
        {
            if(Input.GetKey(KeyCode.E))
            {
                Debug.Log("Get");
                RCplayer.GetRecord(recordNum);
                Destroy(this.gameObject);
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
