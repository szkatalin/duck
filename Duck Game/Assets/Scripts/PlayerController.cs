﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    /*
     * Mozgáshoz tartozik
     * */
    public float moveSpeed;
    private Rigidbody2D myRigidbody;

    public float jumpSpeed;

    public Transform groundCheck;
    public float groundCheckedRadius;
    public LayerMask whatIsGround; //mi is a föld

    public bool isGrounded;

    /*
     * Animációhoz tartozik
     * */
    private Animator myAnimator;


	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
           
        //ellenőrzi, hogy a Ground-on van-e, ugrásnál kell!
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckedRadius, whatIsGround);

        //jobbra
		if( Input.GetAxisRaw("Horizontal") > 0f)
        {
            myRigidbody.velocity = new Vector3(moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(3f, 3f, 3f);
        } else if (Input.GetAxisRaw("Horizontal") < 0f) //balra
        {
            myRigidbody.velocity = new Vector3(-moveSpeed, myRigidbody.velocity.y, 0f);
            transform.localScale = new Vector3(-3f, 3f, 3f);
        } else
        {
            myRigidbody.velocity = new Vector3(0f, myRigidbody.velocity.y, 0f);
        }

        //ugrás
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, jumpSpeed, 0f);
        }

        //ugrás animációhoz, átadjuk mikor ér a földhöz
        myAnimator.SetBool("Grounded", isGrounded);
    }
}