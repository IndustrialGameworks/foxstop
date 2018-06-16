﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using yo ho ass

public class sawSpawner : MonoBehaviour {
	public int timeModifier = 50; //higher timeModifier is, less likely saw to spawn, less saws to dodge
	public GameObject newSawBlade;
	private Vector3 lastSawLocation;

	void Start () {
		lastSawLocation = new Vector3 (transform.position.x - 999f, 2.25f);
	}

	// Update is called once per frame
	void Update () {
		if (Random.Range (0, timeModifier) >= timeModifier - 1
			&& transform.position.x - lastSawLocation.x > -25f) {
			SpawnSawblade ();
		}
	}

	void SpawnSawblade(){
		Instantiate (newSawBlade, new Vector3 (transform.position.x + 30f, 2.25f), Quaternion.identity);
		lastSawLocation = new Vector3 (transform.position.x + 30f, 2.25f);
	}
}