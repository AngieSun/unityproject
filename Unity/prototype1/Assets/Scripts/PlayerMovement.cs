using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour {
    private float movement;
    private Rigidbody2D rigidBody;
    public Transform rotateLimitCheck;
    public GameObject projectile;
    public float power = 0f;




    // Use this for initialization
    Vector2 bulletPos;


    void Start() {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        movement = Input.GetAxis("Vertical");
        if (movement > 0f && rotateLimitCheck.rotation.z < 0.7) {
            transform.parent.Rotate(0, 0, 1);
        }
        else if (movement < 0f && rotateLimitCheck.rotation.z > -0.4)
        {
            transform.parent.Rotate(0, 0, -1);
        }
        if (Input.GetKeyUp("space"))
        {
            fire();
            StartCoroutine(Wait());
            
        }
        if (Input.GetButton("space"))
        {
            power++;
           
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        power = 0f;
    }


    void fire()
    {
        bulletPos = transform.position;
        GameObject proj = Instantiate(projectile, bulletPos, Quaternion.identity);
       // Vector3 targetOffset = new Vector3(power, 0f, 0f);
       // float a = rotateLimitCheck.rotation.z * Mathf.Deg2Rad; //convert angle to radian
       // Debug.Log("The target offset is" + targetOffset);
       // Vector3 dir = targetOffset - transform.position;
       // float height = dir.y;
       // dir.y = 0;
       // float dist = dir.magnitude;
       // dir.y = dist * Mathf.Tan(a);
       // dist += height / Mathf.Tan(a);
       // proj.GetComponent<Rigidbody2D>().velocity = dir.normalized * (float)Math.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a));

    }

        
}
