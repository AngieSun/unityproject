using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scripts : MonoBehaviour {
    public int score = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        Debug.Log("Triggered");
        Destroy(gameObject);
        score= score+1;
        Debug.Log(score);
    }

}
