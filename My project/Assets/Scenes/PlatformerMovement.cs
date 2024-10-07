using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 1.0f;
    [SerializeField]
    float jumpSpeed = 2.0f;
    Rigidbody2D rb;
    bool grounded = false;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //left and right movement based on horizonal axis input
        float moveX = Input.GetAxis("Horizontal");
        Vector2 velocity = GetComponent<Rigidbody2D>().velocity;
        velocity.x = moveX * moveSpeed;
        rb.velocity = velocity;
        //jump when we hit spacebar
        if (Input.GetButtonDown("Jump") && grounded)
        {
            rb.AddForce(new Vector2(0, 100 * jumpSpeed));
            grounded = false;
        }
        anim.SetBool("grounded", grounded);
        anim.SetFloat("y", velocity.y);
        int x = (int)Input.GetAxisRaw("Horizontal");
        anim.SetInteger("x", x);
        if (x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
            

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = false;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
} 

