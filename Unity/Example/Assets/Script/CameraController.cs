using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    //how far camera will be away from player
    public float offset;
    public Vector3 playerPosition;
    public float offsetSmoothing;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        //make position of camera the position of player 
        //transform.position = player.transform.position;
        //not good bc both will be on same z axis position.
        // keep same camera position on y and z axis position
        //transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        playerPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f)
        {
            playerPosition = new Vector3(playerPosition.x + offset, playerPosition.y, playerPosition.z);
        }
        else
        {
            playerPosition = new Vector3(playerPosition.x - offset, playerPosition.y, playerPosition.z);
        }
        //Lerp smoothly transitions camera to its new position
        //deltaTime makes transition smooth no matter how fast/slow computer is
        transform.position = Vector3.Lerp(transform.position, playerPosition, offsetSmoothing * Time.deltaTime); 
    }
}
