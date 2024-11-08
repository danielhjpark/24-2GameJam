using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravelController : MonoBehaviour
{
    [SerializeField]
    public bool canTimeTravel = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(canTimeTravel == false && other.gameObject.tag == "TimeObject")
        {
            canTimeTravel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (canTimeTravel == true && collision.gameObject.tag == "TimeObject")
        {
            canTimeTravel = false;
        }
    }
}
