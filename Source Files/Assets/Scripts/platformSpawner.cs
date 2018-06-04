using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour {
	public GameObject platform;
	float startFoxDistance = 0f;
	float endFoxDistance = 0f;

	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		endFoxDistance = transform.position.x - startFoxDistance;
		SpawnPlatforms ();
		
	}

	void SpawnPlatforms(){
		if ((endFoxDistance / 10f) > 1) {
			endFoxDistance = 0f;
			startFoxDistance = transform.position.x;
			Instantiate (platform, new Vector3 (transform.position.x + 30f, 0), Quaternion.identity);
		}
	}
}
