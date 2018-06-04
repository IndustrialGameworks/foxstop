using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	Rigidbody2D fox;
	Animator animator;

	float initialValueX;
	public static float distance;
	string log;

	float speed = 10;
	float storedSpeed = 10;
	public float jumpStrength;

	public static bool isDead;

	public Transform groundedEnd;
	public bool canJump;

	// Use this for initialization
	void Start () {
		initialValueX = transform.position.x;

		fox = gameObject.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator>();
		isDead = false;
		if (Input.GetKey (KeyCode.Space)) {
			speed = storedSpeed;
			transform.Translate (Vector2.right * speed * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		CharacterAnimation ();
		jumpCheck ();

		DistanceTracking ();
		OnGUI ();
	}

	//Controls fox movement
	void Movement() {
		if (isDead == true) {
			return;
		}
		else {
			if (Input.GetKey (KeyCode.Z) && canJump == true) {
				speed = 0;
			}
			else if (Input.GetKey (KeyCode.X) && canJump == true) {
				fox.AddForce(Vector2.up * jumpStrength);
				print ("jump pressed");
			}
			else {
				speed = storedSpeed;
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			}
        }
	}

	void jumpCheck () {
		Debug.DrawLine (this.transform.position, groundedEnd.position, Color.green);
		canJump = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
	}


	//Connects fox to sprites/animation
	void CharacterAnimation() {
		animator.SetFloat ("foxSpeed", speed);
	}

	//Controls death state
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Deadly" || other.tag == "Wave"){
			animator.SetBool ("foxDead", true);
			isDead = true;
		}
	}

	//Tracks the distance travelled
	void DistanceTracking () {
		distance = transform.position.x - initialValueX;
		distance = distance / 2;
		distance = Mathf.RoundToInt (distance);
		log = distance.ToString ();
	}

	//Outputs the distance travelled to screen
	void OnGUI () {
		GUI.Label (new Rect (100, 100, 100, 100),"Distance: " + log + "m");
	}
		
}
