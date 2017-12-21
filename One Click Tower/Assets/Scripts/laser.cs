using UnityEngine;
using System.Collections;

public class laser : MonoBehaviour {

	public Rigidbody2D rb;
	public Animator anim;

	public bool ActiveLaser;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator> ();

		ActiveLaser = true;

		if (ActiveLaser == true) {
			GameObject laser = Instantiate (Resources.Load ("laserbeam")) as GameObject; 
			laser.transform.parent = transform;
			laser.transform.position = new Vector3 (transform.localPosition.x, transform.localPosition.y+1.8f, transform.localPosition.z);

			laser.name = "laserbeam";

		}

	}

	void OnTriggerEnter2D (Collider2D trigger)
	{
		if (trigger.gameObject.name == "Hero") {
			ActiveLaser = false;
			//Destroy (GameObject.Find("laserbeam"), 0.0f);

			foreach (Transform child in this.transform) {
				GameObject.Destroy(child.gameObject);
			}
			Debug.Log ("Laser trigger");
		}
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("activelaser", ActiveLaser);
	}
}
