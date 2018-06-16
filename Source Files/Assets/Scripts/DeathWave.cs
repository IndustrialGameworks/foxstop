using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathWave : MonoBehaviour {

	float hazardLocationX;
	float controllerSpeed = Controller.storedSpeed;
	public float speed = 8;
	public float foxDistance;
	public Image hazardIndicator;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		hazardLocationX = transform.position.x;
		Movement ();
		DistanceTracking ();
		HazardBar ();
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

	void HazardBar ()
	{
		hazardIndicator.rectTransform.localPosition = new Vector2 (150 -foxDistance * 6, 0);
		if (foxDistance < 0) 
		{
			hazardIndicator.rectTransform.localPosition = new Vector2 (150, 0);	
		}
	}
}
