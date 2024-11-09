using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FathersCup : MonoBehaviour
{
    [SerializeField] public Transform moveTransform;
    [SerializeField] public CheckScript check;
    [SerializeField] private PlaySound playSound;

    [SerializeField] public bool canGet = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && moveTransform != null)
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
                this.transform.position = moveTransform.position;
                check.Clear();
                playSound.Play();
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
