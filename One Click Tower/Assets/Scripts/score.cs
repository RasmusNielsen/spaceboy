using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
 
	public Text playerscore;
	public GameObject player;

	private int currentscore;


	// Use this for initialization
	void Start () {

	}



	// Update is called once per frame
	void Update () {

		if (player) {
			playerscore.text = GenerateLevel.instance.currentLevelNumber.ToString();
		}

	}
}
