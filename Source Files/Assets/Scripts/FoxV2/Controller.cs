﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	float initialValueX;
	public static float distance;
	string log;

	public static float speed = 10;
	float storedSpeed = 10;
	public static float jumpStrength = 100;

	public static bool isDead;

	public Text Score;
	public Text highScore;
	public Button exitButton;
	public Button retryButton;

	// Use this for initialization
	void Start () {
		initialValueX = transform.position.x;
		isDead = false;
		highScore.text = "HighScore : " + PlayerPrefs.GetFloat("HighScore", 0).ToString() + "m";
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		DistanceTracking ();
		Score.text = "Score : " + log + "m";

		if (isDead == true) {
			ShowUI ();
		}
	}

	//Controls fox movement
	void Movement() {
		if (isDead == true) {
			return;
		}
		else {
			if (Input.GetKey (KeyCode.Z) && Fox.canJump == true) {
				speed = 0;
			}
			else if (Input.GetKey (KeyCode.X) && Fox.canJump == true) {
				Fox.Jumping ();
			}
			else {
				speed = storedSpeed;
				transform.Translate (Vector2.right * speed * Time.deltaTime);  
			}
        }
	}

	//Tracks the distance travelled
	void DistanceTracking () {
		distance = transform.position.x - initialValueX;
		distance = distance / 2;
		distance = Mathf.RoundToInt (distance);
		log = distance.ToString ();

		if (distance > PlayerPrefs.GetFloat ("HighScore", 0)) 
		{
			PlayerPrefs.SetFloat ("HighScore", distance);
			highScore.text = "HighScore : " + distance.ToString () + "m";
		}
	}

	void ShowUI()
	{
		exitButton.gameObject.SetActive (true);
		retryButton.gameObject.SetActive (true);
	}
}