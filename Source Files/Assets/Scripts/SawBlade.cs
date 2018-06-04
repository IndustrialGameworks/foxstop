using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBlade : MonoBehaviour {

	public float minSpeed;
	public float maxSpeed;
	float currentSpeed;
	float distance = 4f;

    float posX;
    float posY;

    float lowestHeight;
    float highestHeight;
	float startHeight;

	bool goingUp = coinFlip();

    // Use this for initialization
    void Start () {
        posX = transform.localPosition.x;

        lowestHeight = transform.localPosition.y;
        highestHeight = transform.localPosition.y + distance;
		startHeight = Random.Range(lowestHeight, highestHeight);

        Debug.Log(lowestHeight + " ... " + highestHeight);
		currentSpeed = Random.Range (minSpeed, maxSpeed);

    }
	
	// Update is called once per frame
	void Update () {
        posY = transform.localPosition.y;
        Movement();
	}

	public static bool coinFlip (){
		return(Random.value > 0.5f);
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
