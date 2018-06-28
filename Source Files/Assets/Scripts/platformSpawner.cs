using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour {
	public GameObject platform;
	float startFoxDistance = 0f;
	float endFoxDistance = 0f;
	public int timeModifier = 50; //higher timeModifier is, less likely saw to spawn, less saws to dodge
	public GameObject newSawBlade;
	public GameObject newSpikeWall;
	public GameObject newFirePit;
	private bool spawningPit;
	private Vector3 lastObstacleLocation;

	void Start () {
		lastObstacleLocation = new Vector3 (transform.position.x - 999f, 2.25f);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		endFoxDistance = transform.position.x - startFoxDistance;
		SpawnPlatforms ();
		if (Random.Range (0, timeModifier) >= timeModifier - 1
		    && transform.position.x - lastObstacleLocation.x > -25f) {
			SpawnObstacle ();
		}
	}

	void SpawnObstacle(){
		int chance = Random.Range (0, 9);
		if (chance >= 8){
			spawningPit = true;
			lastObstacleLocation = new Vector3 (transform.position.x + 50f, 4.14f);
		} else if (chance < 6){
			SpawnSaw();
		} else{
			SpawnSpikeBlock ();
		}
	}


	void SpawnPlatforms(){
		if ((endFoxDistance / 10f) > 1) {
			endFoxDistance = 0f;
			startFoxDistance = transform.position.x;
			if (!spawningPit) {
				Instantiate (platform, new Vector3 (transform.position.x + 30f, 4.14f), Quaternion.identity);
			} else {
				Instantiate (newFirePit, new Vector3 (transform.position.x + 30f, 4.14f), Quaternion.identity);
				spawningPit = false;
			}
		}
	}

	void SpawnSaw(){
		Instantiate (newSawBlade, new Vector3 (transform.position.x + 30f, 2.25f), Quaternion.identity);
		lastObstacleLocation = new Vector3 (transform.position.x + 35f, 2.25f);
	}

	void SpawnSpikeBlock(){
		Instantiate (newSpikeWall, new Vector3 (transform.position.x + 40f, 0.73f), Quaternion.identity);
		lastObstacleLocation = new Vector3 (transform.position.x + 50f, 0.73f);
	}
}
