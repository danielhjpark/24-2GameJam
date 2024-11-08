using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 10.0f;
    [SerializeField]
    private float JumpForce = 5.0f;

    Rigidbody2D rigid;

    private SpriteRenderer playerSpriteRenderer;


    public GameObject target;

    Vector3 movement;
    bool isJumping = false;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            playerSpriteRenderer.flipX = false; //플레이어 스프라이트 반전
        }

        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            playerSpriteRenderer.flipX = true;//플레이어 스프라이트 반전
        }

        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
    }

    void Jump()
    {
        if (!isJumping)
            return;

        //Prevent Velocity amplification.
        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, JumpForce);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
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
