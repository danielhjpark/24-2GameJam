using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kettle : MonoBehaviour
{
    [SerializeField] ManCup mancup;
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
        if (canGet)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Get");
                mancup.hasHotWater = true;
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
