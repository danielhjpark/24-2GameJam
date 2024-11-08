using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 10.0f;

    Rigidbody2D rigid;

    private SpriteRenderer playerSpriteRenderer;


    public GameObject target;

    Vector3 movement;

    public bool isMoving = true;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        if(isMoving)
        {
            Move();
        }
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity += Vector3.left;
            playerSpriteRenderer.flipX = false; //플레이어 스프라이트 반전
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity += Vector3.right;
            playerSpriteRenderer.flipX = true;//플레이어 스프라이트 반전
        }

        if(Input.GetAxisRaw("Vertical") < 0)
        {
            moveVelocity += Vector3.down;
        }
        else if(Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity += Vector3.up;
        }

        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TalkTag")
        {
            target = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "TalkTag")
        {
            target = null;
        }
    }
}
