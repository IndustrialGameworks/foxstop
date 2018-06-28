using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBenchBlade : MonoBehaviour {

	public float minSpeed;
	public float maxSpeed;
	float currentSpeed;
	float distance = 12f;

	float posX;
	float posY;

	float furthestLeft;
	float furthestRight;
	float startPosition;

	bool goingUp = coinFlip();
	bool moveY;

	// Use this for initialization
	void Start () {
		posX = transform.localPosition.x;

		furthestRight = transform.localPosition.x;
		furthestLeft = transform.localPosition.x + distance;
		startPosition = Random.Range(furthestRight, furthestLeft);

		Debug.Log(furthestRight + " ... " + furthestLeft);
		currentSpeed = Random.Range (minSpeed, maxSpeed);

	}

	// Update is called once per frame
	void Update () {

		posX = transform.localPosition.x;
		Movement();
	}

	public static bool coinFlip (){
		return(Random.value > 0.5f);
	}

	void Movement() {
		if (moveY == true) {
			//move Y
		}

		if (goingUp == true) {
			if (posX >= furthestLeft) {
				goingUp = false;
			}
		} else {
			if (posX <= furthestRight) {
				goingUp = true;
			}
		}

		if (goingUp == true) { 
			transform.Translate (new Vector2 (currentSpeed * Time.deltaTime,0));
		} else {
			transform.Translate (new Vector2 (-currentSpeed * Time.deltaTime,0));
		}
	}
}
