using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ManCup : MonoBehaviour
{
    [SerializeField] public bool hasHotWater = false;
    [SerializeField] public CheckScript check;
    [SerializeField] public bool canGet = false;
    [SerializeField] public PlaySound sound;

    [SerializeField]
    private Sprite SmokeSprite;

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
                this.gameObject.GetComponent<SpriteRenderer>().sprite = SmokeSprite;
                sound.Play();
                GameManager.Instance.Player.isMoving = false;
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
        Destroy(this);
    }
}
