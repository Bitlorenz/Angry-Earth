using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

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

            //rigidBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            //rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            rigidBody.velocity = new Vector2(0f, 0f);//changes velocity to 0
            rigidBody.velocity = Vector2.up * jumpForce;//moves character with initial velocity 0
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
}