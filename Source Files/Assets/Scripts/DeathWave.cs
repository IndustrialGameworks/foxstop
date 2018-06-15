using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWave : MonoBehaviour {

	float hazardLocationX;
	float controllerSpeed = Controller.storedSpeed;
	public float speed = 8;
	public float foxDistance;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		hazardLocationX = transform.position.x;
		Movement ();
		DistanceTracking ();
	}

	// Tracks distance between the wave and the fox
	void DistanceTracking () {
		foxDistance = Fox.foxLocationX - hazardLocationX;
	}

	//Controls movement
	void Movement () {
		if (foxDistance >= 50) {
			transform.Translate (Vector2.right * controllerSpeed * Time.deltaTime);
		} else {
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
	}
}
