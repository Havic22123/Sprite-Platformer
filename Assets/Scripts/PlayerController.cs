using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Transform tf;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private Animator animator;

    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public Transform groundPoint;
    public bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal") * speed;
        rb2d.velocity = new Vector2(xMovement, rb2d.velocity.y);
        
        // Detect if the player is on the ground
        RaycastHit2D hitInfo = Physics2D.Raycast(groundPoint.position, Vector2.down, 0.1f);
        if (isGrounded)
        {
            speed = speed-1f;
        }
        if (isGrounded && speed<5)
        {
            speed = 5f;
        }
        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        if(xMovement > 0 && isGrounded)
        {
            sr.flipX = false;
            animator.Play("Sprite Walk");
        }
        else if(xMovement < 0 && isGrounded)
        {
            sr.flipX = true;
            animator.Play("Sprite Walk");
        }
        else if(isGrounded)
        {
            animator.Play("Sprite Idle");
        }
        // Jump
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce);
        }
        if (xMovement > 0 && !isGrounded)
        {
            sr.flipX = false;
            animator.Play("Sprite Jump");
            speed = speed + 0.15f;
            if (speed > 20)
            {
                speed = 20f;
            }
        }
        if (xMovement < 0 && !isGrounded)
        {
            sr.flipX = true;
            animator.Play("Sprite Jump");
            speed = speed + 0.15f;
            if(speed > 20)
            {
                speed = 20f;
            }
        }

    }
}
