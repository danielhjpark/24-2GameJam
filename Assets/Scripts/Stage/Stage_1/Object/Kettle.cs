using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kettle : MonoBehaviour
{
    [SerializeField] ManCup mancup;
    [SerializeField] public bool canGet = false;
    [SerializeField] private PlaySound soundPlay;

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
                soundPlay.Play();
                StartCoroutine(Stop());
                
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

    IEnumerator Stop()
    {
        GameManager.Instance.Player.isMoving = false;
        yield return new WaitForSeconds(2.0f);
        GameManager.Instance.Player.isMoving = true;
        Destroy(this.gameObject);
    }
}
