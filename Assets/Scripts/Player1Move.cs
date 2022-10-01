using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class Player1Move : MonoBehaviour
{
    Rigidbody2D rigidBody;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public float moveSpeed = 10f;
    public float jumpForce = 2f;
    public float movementX;

    public bool isGrounded = true;
    public bool doubleJump = true;
    public string GROUND = "Ground";
    public string JUMP = "Jump";
    public string WALK = "Walk";
    public string FALL = "Fall";
    public string IDLE = "Idle";

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMove();
        PlayerJump();
        AnimatePlayer();
    }

    private void FixedUpdate()
    {
        
    }

    void PlayerMove()
    {
        movementX = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveSpeed;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && (doubleJump || isGrounded) )
        {
            if (!doubleJump)
                isGrounded = false;

            if (doubleJump)
                doubleJump = false;

            rigidBody.velocity = new Vector2(0f, 0f);
            rigidBody.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded=true;
            doubleJump=true;
            Debug.Log("Ground");
        }
    }

    void AnimatePlayer()
    {
        if (rigidBody.velocity.y == 0 )
        {
            anim.SetBool(WALK , false);
            anim.SetBool(IDLE , true);
            anim.SetBool(FALL , false);
            anim.SetBool(JUMP , false);
        }    
        if (rigidBody.velocity.y > 0 )
        {
            anim.SetBool(JUMP , true);
        }    
        if (rigidBody.velocity.y < 0)
        {
            anim.SetBool(JUMP , false);
            anim.SetBool(FALL , true);
        }
        if (movementX > 0)
        {
            anim.SetBool(WALK, true);
            anim.SetBool(IDLE, false);
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK, true);
            anim.SetBool(IDLE, false);
        }
        else
        {
            anim.SetBool(WALK, false);
            anim.SetBool(IDLE, true);
        }
    }
}
