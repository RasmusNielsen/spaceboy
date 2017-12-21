using UnityEngine;
using System.Collections;

public class rotating_crate : MonoBehaviour {

	public bool rotating;
	public Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		rotating = true;

	}


	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("rotating", rotating);

	}
}
