using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sawSpawner : MonoBehaviour {
	public int timeModifier = 100; //higher timeModifier is, less likely saw to spawn, less saws to dodge
	public GameObject newSawBlade;

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!Input.GetKey(KeyCode.Space)){
			if (Random.Range (0, timeModifier) >= timeModifier - 1) {
				SpawnSawblade ();
			}
		}
	}

	void SpawnSawblade(){
		Instantiate (newSawBlade, new Vector3 (transform.position.x + 30f, 2.25f), Quaternion.identity);
	}
}
