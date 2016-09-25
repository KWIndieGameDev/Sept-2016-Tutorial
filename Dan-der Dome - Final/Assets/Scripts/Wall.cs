using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		// bullets contacting wall
		if (other.gameObject.tag == "Bullet") {

			Destroy (other.gameObject);
		}

		if (other.gameObject.tag == "EnemyBullet") {

			Destroy (other.gameObject);
		}
	}
}
