using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Creditscroll : MonoBehaviour
{
    [SerializeField]
    private GameObject credits;
    [SerializeField]
    private GameObject gamename;
    [SerializeField]
    private float moveSpeed = 200f;
    [SerializeField]
    private float maxMoveDistance = 2500f;
    [SerializeField]
    private float maxMoveName = 1000f;

    private Vector3 startPosition;

    private Vector3 nameStartPosition;

    [SerializeField]
    private bool isNameMove = false;

    private void Start()
    {
        startPosition = credits.transform.position;
        nameStartPosition = gamename.transform.position;
        StartCoroutine(MoveGamename());
    }

    public void Update()
    {
        // ���� �̵� �Ÿ��� ���
        float distanceMoved = Vector3.Distance(startPosition, credits.transform.position);

        // �ִ� �̵� �Ÿ����� ������ ���� �̵�
        if (distanceMoved < maxMoveDistance)
        {
            credits.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        else
        {
            // �ִ� �Ÿ��� �����ϸ� ����
            credits.transform.position = startPosition + Vector3.up * maxMoveDistance;
        }
        if(isNameMove)
        {
            // ���� �̵� �Ÿ��� ���
            float nameDistanceMoved = Vector3.Distance(nameStartPosition, gamename.transform.position);

            // �ִ� �̵� �Ÿ����� ������ ���� �̵�
            if (nameDistanceMoved < maxMoveName)
            {
                gamename.transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            }
            else
            {
                // �ִ� �Ÿ��� �����ϸ� ����
                gamename.transform.position = nameStartPosition + Vector3.up * maxMoveName;
            }
        }
    }

    IEnumerator MoveGamename()
    {
        yield return new WaitForSeconds(5.0f);
        isNameMove = true;
    }
}
