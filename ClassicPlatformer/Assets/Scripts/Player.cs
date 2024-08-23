using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //references
    public Rigidbody2D rb;
    public int moveSpeed;
    public int jumpPower;

    public Transform groundCheck; //point that has coordinates and rotation(angle)
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;

    private Animator anim;
    private int facing;

    public int coins;

    public GameObject Blood;//

  

    //mobile controls
    public bool moveLeft;
    public bool moveRight;

    //checkpoints
    public float startx;
    public float starty;

    public AudioSource bd;


    // Start is called before the first frame update
    void Start()
    {
        bd.Play();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = 3;
        jumpPower = 7;
        facing = 1;

        startx = transform.position.x;
        starty = transform.position.y;

    }

    //more consistent and more reliable code to physics
    void FixedUpdate()
    {
        //true/false statement
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        //Controlling the Player
        
        //move
        if (moveLeft || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            anim.SetBool("walking", true);
            if (facing == 1)
            {
                //flip player sprite to opposite direction
                transform.localScale = new Vector3(-1f, 1f, 1f);
                facing = 0;
            }
        }

        else if (moveRight || Input.GetKey(KeyCode.RightArrow))
        {
            //add velocity with movespeed to the horizontal X of rb 
            //vector is a coordinate
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            anim.SetBool("walking", true);
            if (facing == 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
                facing = 1;
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }

        //Jump
        if (Input.GetKey(KeyCode.UpArrow) && onGround)
        {
            jump();
        }


    }

    //reference public method to jump
    public void jump()
    {
        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower); 
        }
    }

    public void Death()
    {
        //wait 1 second b4 return
        StartCoroutine("respawndelay");
    }

    public IEnumerator respawndelay()
    {
        Instantiate(Blood, transform.position, transform.rotation);
        enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(1);
        transform.position = new Vector2(startx, starty);
        GetComponent<Renderer>().enabled = true;
        enabled = true;
    }

    //for Spring
    public void SuperJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpPower * 2);
    }

}
