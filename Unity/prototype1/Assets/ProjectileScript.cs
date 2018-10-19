using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ProjectileScript : MonoBehaviour {
    public Vector2 gravity = new Vector3(0f, -9.8f, 0f);
    private float angle;
    public float velocityX;
    public float velocityY;

    Rigidbody2D rb;

        // Use this for initialization
	void Start () {
       rb = GetComponent<Rigidbody2D>();
        angle = GameObject.Find("Aimer").transform.rotation.z;
        float power = GameObject.Find("turret").GetComponent<PlayerMovement>().power;
        velocityX = (float)( power * 0.2 * Math.Cos(angle));
        velocityY = (float)( power * 0.2 * Math.Sin(angle));
        Debug.Log(angle);
        rb.velocity = new Vector2(velocityX, velocityY );
    }

    

    // Update is called once per frame
    void FixedUpdate () {
        rb.velocity += gravity * Time.fixedDeltaTime;
 	}
}          
