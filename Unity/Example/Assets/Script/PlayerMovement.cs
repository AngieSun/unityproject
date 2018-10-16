using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float jumpSpeed = 5f;
    public float speed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;

    //checks if player is on the ground with bottom of character
    public Transform groundCheckPoint; // anything that has a transform property
    //radius around that bottom of character
    public float groundCheckRadius;
    //layer that is defined as ground
    public LayerMask groundLayer;
    private bool isTouchingGround;


    private Animator playerAnimation; 


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
        //overlap checks if there are any objects from groundlayer within radius from position
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        else if(movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }
        //if input button for jump is pressed 
        if (Input.GetButtonDown("Jump") && isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }

        //sends info about x-dir velocity to speed param in unity
        playerAnimation.SetFloat("speed", Mathf.Abs(rigidBody.velocity.x));
        playerAnimation.SetBool("onGround", isTouchingGround);

    }
     
        
}
