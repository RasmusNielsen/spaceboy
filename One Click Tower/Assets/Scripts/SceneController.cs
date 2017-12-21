using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
	
	public void ChangeToScene (string sceneToChangeTo) {
		SceneManager.LoadScene(sceneToChangeTo);

	}
}

