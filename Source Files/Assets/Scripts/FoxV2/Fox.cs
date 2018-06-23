using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour {

	public static Rigidbody2D foxRigid;
	Animator animator;

	public static float foxLocationX;
	public static float foxLocationY;
	public Transform groundedEnd;
	public static bool canJump;
	public static bool isJumping;

	public static float foxMaxHeight = 5.5f;

	// Use this for initialization
	void Start () {
		foxRigid = gameObject.GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		CharacterAnimation ();
		JumpCheck ();

		//Runs the jump method
		if (isJumping == true) {
			Jumping ();
		}

		foxLocationX = transform.position.x;
		foxLocationY = transform.position.y;
	}

	void JumpCheck () {
		Debug.DrawLine (this.transform.position, groundedEnd.position, Color.green);
		canJump = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer("Ground"));
	}

	public static void Jumping () {
		if (foxLocationY <= foxMaxHeight) {
			foxRigid.transform.Translate (new Vector2 (0, Controller.jumpStrength * Time.deltaTime));
			//foxRigid.AddForce (Vector2.up * Controller.jumpStrength);
			print ("jump pressed");
		} else {
			isJumping = false;
		}
	}

	//Controls death state
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Deadly" || other.tag == "Wave"){
			animator.SetBool ("foxDead", true);
			Controller.isDead = true;
		}
	}

	//Connects fox to sprites/animation
	void CharacterAnimation() {
		animator.SetFloat ("foxSpeed", Controller.speed);
	}
}
