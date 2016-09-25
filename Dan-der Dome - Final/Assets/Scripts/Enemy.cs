using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;
	private Transform player;
	public float distance = 2f;

	// Laser

	public GameObject bullet;
	public Transform enemyBulletSpawn;
	public float enemyFireRate;
	public float enemyNextFire;

	private Rigidbody2D rb2D;

	void Start () {

		rb2D = GetComponent<Rigidbody2D>();

		player = GameObject.Find ("Player").GetComponent<Transform> ();

	}

	void FixedUpdate () {

		if (GameManager.instance.health != 0) {

			// rotates enemy to face player
			float z = Mathf.Atan2 ((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;

			transform.eulerAngles = new Vector3 (0, 0, z);

			// moves enemy towards player
			float h = Mathf.Sqrt ((player.transform.position.y - transform.position.y) * (player.transform.position.y - transform.position.y) + (player.transform.position.x - transform.position.x) * (player.transform.position.x - transform.position.x));

			if (h > 2f) {
				rb2D.AddForce (gameObject.transform.up * speed);
			}  else {
				rb2D.velocity = Vector3.zero;
			}
		}
	}

	void Update () {

		if (GameManager.instance.health != 0) {

			// enemy fires bullet
			if (Time.time > enemyNextFire) {
				enemyNextFire = Time.time + enemyFireRate;
				Instantiate (bullet, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.gameObject.tag == "Bullet") {

			// emeny is hit buy bullet
			Destroy (gameObject);
			Destroy (other.gameObject);
			GameManager.instance.remaining = GameManager.instance.remaining - 1;
			GameManager.instance.remainingText.text = "REMAINING DANS: " + GameManager.instance.remaining;
		}
	}
}