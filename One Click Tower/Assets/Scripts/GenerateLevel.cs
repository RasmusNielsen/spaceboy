using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class OnHeroHitPlatformEvent : UnityEvent<int>
{
}

public class GenerateLevel : MonoBehaviour {

	public OnHeroHitPlatformEvent onHeroHitPlatformEvent;

	public static GenerateLevel instance = null;

	public int centerScreen;
	private int nextNameNumber = 0;
	private float xPosLadder = 4.4f;
	private float groundlevel = 0.75f;
	private int randomXPos;


	public int easy = 1;
	public int medium = 10;
	public int hard = 15;
	public int vhard = 20;

	public int currentLevelNumber = 0;
	private int levelSpawnCount = 0;

	public Renderer rend;

	void Awake()
	{
		//Check if instance already exists
		if (instance == null) {
			instance = this;

			this.onHeroHitPlatformEvent = new OnHeroHitPlatformEvent ();
			this.onHeroHitPlatformEvent.AddListener (onHeroHitPlatform);
		}
	}
		
	void onHeroHitPlatform(int level) {
		if (level != currentLevelNumber) { // level changed.
			currentLevelNumber = level;
			createLevelsAHeadOfPlayer ();
		}
	}

	void Start () {
		centerScreen = Screen.width / 2;

		rend = GetComponent<Renderer>();


		this.createLevelsAHeadOfPlayer ();
	}

	void createLevelsAHeadOfPlayer() {
		int spawnAheadCount = 5; // how many levels should be spawned ahead of the current level.
		int spawnFrom = Mathf.Max(currentLevelNumber, levelSpawnCount);
		int spawnTo = (currentLevelNumber + spawnAheadCount);

		//Debug.Log ("spawn-new: from(" + spawnFrom + ") to:(" + spawnTo + ")");

		for (int level = spawnFrom; level < spawnTo; level++) {
			instantiateLevel(level);

			levelSpawnCount = Mathf.Max (levelSpawnCount, level + 1);
		}

		//Debug.Log ("spawn-new: count " + levelSpawnCount);
	}


	string generateRandomLevel(int i)  {
		if (i == 0) {
			return "level_start";
		}

		if (i == 1) {
			return "level_hard_left_3";
		}
						
		if (i % 2 == 0) {
			// jump right
			if (i < medium)  {
				// easy	
				int random = Random.Range(1,4);
				return "level_easy_right_" + random;

			} else if (i < hard)  {
				// medium
				int random = Random.Range(1,4);
				return "level_medium_right_" + random;
			} else if (i < vhard)  {
				// hard
				int random = Random.Range(1,4);
				return "level_hard_right_" + random;
			} else {
				// vhard
				int random = Random.Range(1,4);
				return "level_vhard_right_" + random;
			}

			// remove these when above is done
			//return "level_jump";
		} else {
			// jump left

			if (i < medium)  {
				// easy	
				int random = Random.Range(1,4);
				return "level_easy_left_" + random;
			} else if (i < hard)  {
				// medium
				int random = Random.Range(1,4);
				return "level_medium_left_" + random;
			} else if (i < vhard)  {
				// hard
				int random = Random.Range(1,4);
				return "level_hard_left_" + random;
			} else {
				// vhard
				int random = Random.Range(1,4);
				return "level_vhard_left_" + random;
			}

			// remove these when above is done
			//return "level_jump_alt";
		}
	}
		
	void instantiateLevel(int i) {
		Debug.Log ("create-new-level: " + i);
		string lvl = generateRandomLevel(i);

		// spawn room
		GameObject cube = Instantiate(Resources.Load(lvl)) as GameObject; 	
		cube.transform.position = new Vector3 (0, i*4, 0);
		// give level number
		cube.name = "level_"+nextNameNumber;

		nextNameNumber++;

		cube.AddComponent<LevelInformation> ();
		LevelInformation info = cube.GetComponent<LevelInformation> () as LevelInformation;
		info.level = i;

		// alternate ladders
		foreach(Transform child in cube.transform)
		{
			if (child.name == "ladder") {
				if (i % 2 == 0) {
					child.transform.localPosition = new Vector3 (xPosLadder, 1, 0);
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {


	}
}
