using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour {

	public float speed;
	public float tempSpeed;
	public bool speedFlipped;

	public bool facingRight;	
	public bool grounded;

	public bool onLadder;

	public bool isReady;

	public float jumpPower;

	private float elevatorBoost = 21f;

	public Rigidbody2D rb;
	public Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
		
	void die () {
		Destroy(gameObject);

		int currentscore = GenerateLevel.instance.currentLevelNumber;

		PlayerPrefs.SetInt("CurrentScore", currentscore);

		GameObject herodie = Instantiate(Resources.Load("hero-dead")) as GameObject; 
		herodie.transform.position = this.transform.position;
	}

	void FlipDirection () {
		if (facingRight) facingRight = false;
		else facingRight = true; 

		transform.Rotate(new Vector3(0,-180,0));

		if (facingRight) {
		} else {
			//transform.Rotate(new Vector3(0,0,0));
		}
	}

	// check if touching ladder
	void OnTriggerEnter2D (Collider2D trigger)
	{

		if (trigger.gameObject.tag == "deadly") {
			die ();
			//rb.AddForce (Vector3.up * jumpPower * elevatorBoost);
		}

		if (trigger.gameObject.tag == "obstacle") {
			die ();
			//rb.AddForce (Vector3.up * jumpPower * elevatorBoost);
		}
			
		if (trigger.gameObject.name == "crate") {
			FlipDirection (); 
		}

		if (trigger.gameObject.name == "laserbase-on") {
			FlipDirection (); 
		}

		if (trigger.gameObject.name == "ladder") {
			rb.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, elevatorBoost);
			onLadder = true;
		} else {
			onLadder = false;
		}
	}

	// check if colliding with wall
	void OnCollisionEnter2D (Collision2D col)


	{
		if(col.gameObject.name == "walls" || col.gameObject.tag == "obstacle")
		{
			FlipDirection (); 
		}
			
		// check if touching ground
		if (col.gameObject.name == "floor" || col.gameObject.name == "platform" || col.gameObject.name == "rotating_crate" || col.gameObject.name == "crate" ) {
			grounded = true;
		} 

		if (col.gameObject.name == "platform") {
			LevelInformation info = col.gameObject.GetComponentInParent (typeof(LevelInformation)) as LevelInformation;
			GenerateLevel.instance.onHeroHitPlatformEvent.Invoke (info.level);
		}
	}

	void OnCollisionStay2D (Collision2D col)
	{
		if (col.gameObject.name == "floor" || col.gameObject.name == "platform" || col.gameObject.name == "jump_platform" || col.gameObject.name == "rotating_crate" || col.gameObject.name == "crate" ) {
			grounded = true;
		} 
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (col.gameObject.name == "floor" || col.gameObject.name == "platform" || col.gameObject.name == "rotating_crate" || col.gameObject.name == "crate" ) {
			grounded = false;

		} 
	}

	void jump (bool grounded) {
		if (grounded) {
			rb.AddForce (Vector3.up * jumpPower);

			// player is ready
			isReady = true;

		}
	}



	void LateUpdate () {

		if (isReady == false && speedFlipped == false) {
			tempSpeed = speed;
			speed = 0;
			speedFlipped = true;
		}

		if (isReady == true && speedFlipped == true) {
			speed = tempSpeed;
		}

	}

	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("space") && (grounded)) {
			jump(grounded);
		}

		// new touch

		for (int i = 0; i < Input.touchCount; ++i) {
			if (Input.GetTouch (i).phase == TouchPhase.Began && (grounded)) {
				jump (grounded);
			}
		}
	
		///

		// Determine number of touches
//		int fingerCount = 0;
//
//		foreach (Touch touch in Input.touches) {
//			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
//				fingerCount++;
//			}
//		}
//		if (fingerCount == 1 && (grounded)) {
//			jump(grounded);
//		}

	
		if (Input.GetKey("z"))
		{
			// slow down time from 1 too 0.5
			Time.timeScale = .05f;
		}
		else 
		{
			Time.timeScale = 1f;
		}
			

		anim.SetBool("IsReady", isReady);
		anim.SetBool("Grounded", grounded);

		if (facingRight == true) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if (facingRight == false) {
			transform.position += Vector3.left * speed * Time.deltaTime;

		} 

	}
		}

