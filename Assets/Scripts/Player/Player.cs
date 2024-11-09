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
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    void Move()
    {
        Debug.Log("CanMoving");
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

        Debug.Log(moveVelocity);

        transform.position += moveVelocity * MoveSpeed * Time.deltaTime;
    }
}
