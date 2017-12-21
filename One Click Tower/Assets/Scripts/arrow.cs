using UnityEngine;
using System.Collections;

public class arrow : MonoBehaviour {

	public float thrust;
	public Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		rb.AddForce(transform.right * thrust);
	}


	void OnBecameInvisible() {
		Destroy(gameObject);
	}

}

