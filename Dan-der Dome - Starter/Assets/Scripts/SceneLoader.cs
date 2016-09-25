using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void StartGame() {

		// loads scene
		SceneManager.LoadScene ("Game");
	}
}
