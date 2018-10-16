using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    private float movement;
    private Rigidbody2D rigidBody;
    public Transform rotateLimitCheck;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent < Rigidbody2D>();	
	}
	
	// Update is called once per frame
	void Update () {
        movement = Input.GetAxis("Vertical");
        if (movement > 0f && rotateLimitCheck.rotation.z < 0.7) {
            transform.parent.Rotate(0, 0, 1);
                }
        else if (movement < 0f && rotateLimitCheck.rotation.z > -0.4)
        {
            transform.parent.Rotate(0, 0, -1);
        }
        else
        { };
        Debug.Log(rotateLimitCheck.rotation.z);
	}
}
