using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class deadanimation : MonoBehaviour {

	public int Switchscene;
	public Animator anim;

	public bool DeadAnimatedEnd;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	
	}

	// Update is called once per frame
	void Update () {

		if (DeadAnimatedEnd == true) {
			SceneManager.LoadScene("GameOver");
		}
	}
}
