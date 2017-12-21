using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Text currentscore;
	public Text highscore;

	public GameObject NewBestSymbol;

	// Use this for initialization
	void Start () {

		int currentscoreint = PlayerPrefs.GetInt("CurrentScore");
		currentscore.text = PlayerPrefs.GetInt("CurrentScore").ToString();

		if (PlayerPrefs.GetInt("CurrentScore") > PlayerPrefs.GetInt("Highscore", 0)){
			PlayerPrefs.SetInt("Highscore", currentscoreint);
			NewBestSymbol.active = true;
		}

		highscore.text = PlayerPrefs.GetInt("Highscore").ToString();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
