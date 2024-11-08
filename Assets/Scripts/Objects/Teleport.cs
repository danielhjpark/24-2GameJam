using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject targetObj;
    public GameObject toObj; //이동되는 포탈

    [SerializeField]
    private bool canTP = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetObj = collision.gameObject;
            canTP = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && canTP)
        {
            Debug.Log("안쪽까지");
            StartCoroutine(TeleportRoutine());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTP = false;
    }
    IEnumerator TeleportRoutine()
    {
        yield return null;
        targetObj.transform.position = toObj.transform.position;
        canTP = false;
    }
}
