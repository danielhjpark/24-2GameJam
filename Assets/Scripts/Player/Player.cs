using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 10.0f;

    Rigidbody2D rigid;
    Animator animator;

    private SpriteRenderer playerSpriteRenderer;


    public GameObject target;

    Vector3 movement;

    public bool isMoving = true;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
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
            playerSpriteRenderer.flipX = true; //플레이어 스프라이트 반전
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity += Vector3.right;
            playerSpriteRenderer.flipX = false;//플레이어 스프라이트 반전
        }

        if(Input.GetAxisRaw("Vertical") < 0)
        {
            moveVelocity += Vector3.down;
        }
        else if(Input.GetAxisRaw("Vertical") > 0)
        {
            moveVelocity += Vector3.up;
        }

        if(moveVelocity != Vector3.zero)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "TalkTag")
        {
            Debug.Log("충돌 됨");
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
