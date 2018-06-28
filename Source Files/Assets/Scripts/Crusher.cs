using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour {

	bool goingUp = false;
	public float currentSpeed;
	float posY;
	float lowestHeight;
	float highestHeight;
	float startHeight;

	// Use this for initialization
	void Start () {
		startHeight = transform.localPosition.y;
		highestHeight = startHeight;
		lowestHeight = highestHeight - 8;
	}
	
	// Update is called once per frame
	void Update () {
		posY = transform.localPosition.y;
		Movement ();
	}

	void Movement() {

		if (goingUp == true)
		{
			if ( posY >= highestHeight)
			{
				goingUp = false;
			}
		}
		else
		{
			if (posY <= lowestHeight)
			{
				goingUp = true;
			}
		}

		if ( goingUp == true)
		{ 
			transform.Translate(new Vector2 (0, currentSpeed * Time.deltaTime));
		}
		else
		{
			transform.Translate(new Vector2(0, -currentSpeed * Time.deltaTime));
		}


	}

}
