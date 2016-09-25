using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject gameManager;

	void Awake ()
	{
		// loads game manager
		if (GameManager.instance == null)
			Instantiate (gameManager);
	}
}
