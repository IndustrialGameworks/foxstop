using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBenchBlade : MonoBehaviour {

	public float minSpeed;
	public float maxSpeed;
	float currentSpeed;
	float distance = 5f;

	float posX;
	float posY;

	float furthestLeft;
	float furthestRight;
	float startPosition;

	bool goingLeft = coinFlip();
	bool moveY;
	bool moveYup = false;

	// Use this for initialization
	void Start () {
		posX = transform.localPosition.x;
		posY = transform.localPosition.y;

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
		if (moveY == true && moveYup == false) {
			transform.Translate (new Vector2 (0,-1.4f)); //moves Y position to make saw run along underside of bench
			moveYup = !moveYup;
			moveY = false;
		}

		if (moveY == true && moveYup == true) {
			transform.Translate (new Vector2 (0,+1.4f)); //resets the Y position to original value
			moveYup = !moveYup;
			moveY = false;
		}

		if (goingLeft == true) {
			if (posX >= furthestLeft) {
				goingLeft = false;
				moveY = true;
			}
		} else {
			if (posX <= furthestRight) {
				goingLeft = true;
				moveY = true;
			}
		}

		if (goingLeft == true) { 
			transform.Translate (new Vector2 (currentSpeed * Time.deltaTime,0));
		} else {
			transform.Translate (new Vector2 (-currentSpeed * Time.deltaTime,0));
		}
	}
}
