using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	float initialValueX;
	public static float distance;
	string log;

	public static float speed = 10;
	public static float storedSpeed = 10;
	public static float jumpStrength;
	public float jumpHeight;

	public static bool isDead;

	public Text Score;
	public Text highScore;
	public Button menuButton;
	public Button retryButton;
	public Button continueButton;
	public Image menuBackground;

	// Use this for initialization
	void Start () {
		initialValueX = transform.position.x;
		isDead = false;
		highScore.text = "HighScore : " + PlayerPrefs.GetFloat("HighScore", 0).ToString() + "m";
		jumpStrength = jumpHeight;
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
		menuButton.gameObject.SetActive (true);
		retryButton.gameObject.SetActive (true);
		continueButton.gameObject.SetActive (true);
		menuBackground.gameObject.SetActive (true);
	}
}
