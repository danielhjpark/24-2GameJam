using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManCup : MonoBehaviour
{
    [SerializeField] public bool hasHotWater = false;
    [SerializeField] public CheckScript check;
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
        if (canGet && hasHotWater)
        {
            if (Input.GetKey(KeyCode.E))
            {
                Debug.Log("Get");
                check.Clear();
                Destroy(this);
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
