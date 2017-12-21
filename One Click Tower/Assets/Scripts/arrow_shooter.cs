using UnityEngine;
using System.Collections;

public class arrow_shooter : MonoBehaviour {

	//float arrowSpeed = 10f;
	public float Timer = 2;
	public GameObject arrow;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		Timer -= Time.deltaTime;
		if (Timer <= 0) 
		{
			Rigidbody2D arrowClone;

			arrowClone = Instantiate (arrow, (new Vector2 (transform.position.x, transform.position.y)), transform.rotation) as Rigidbody2D;
			Timer = 2;

		}
	}
}
