using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D rb2D;
	public GameObject bullet;
	public Transform bulletSpawn;
	public float fireRate;
	public float nextFire;
	public float speed;

	// Use this for initialization
	void Start () {

		rb2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		// player fires bullet
		if (Input.GetButton ("Fire1") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
		}

		// player at 0 health
		if (GameManager.instance.health == 0) {
			Destroy(gameObject);
		}
	}

	void FixedUpdate () {

		// Get horizontally and vertically movement with keys
		float moveHoriztonal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector2 movement = new Vector2 (moveHoriztonal, moveVertical);
		rb2D.velocity = movement * speed;

		// Get mouse position as player will always face mouse
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (mousePosition - rb2D.transform.position, rb2D.transform.TransformDirection (Vector3.forward));
		rb2D.transform.rotation = new Quaternion (0, 0, rot.z, rot.w);

		rb2D.angularVelocity = 0;
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "EnemyBullet") {

			// player is hit by bullet
			Destroy (other.gameObject);
			GameManager.instance.health = GameManager.instance.health - 1;
			GameManager.instance.healthText.text = "Health: " + GameManager.instance.health;
		}
	}
}
