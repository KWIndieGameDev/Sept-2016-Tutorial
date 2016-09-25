using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject enemy;
	public float nextEnemy;
	public float enemyRespawnRate;

	private Transform enemySpawn;
	private Transform enemySpawn2;
	private Transform enemySpawn3;
	private Transform enemySpawn4;

	//private Transform player;

	[HideInInspector] public Text remainingText;
	public int remaining = 10;
	public int totalDans = 10;

	[HideInInspector] public Text healthText;
	public int health = 10;

	[HideInInspector] public Button restartBtn;
	[HideInInspector] public Text restartText;

	public static GameManager instance = null;

	void Awake ()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
	}

	void Start () {

		// finding and setting text
		remainingText = GameObject.Find ("RemainingText").GetComponent<Text> ();
		remainingText.text = "REMAINING DANS: " + remaining;

		healthText = GameObject.Find ("HealthText").GetComponent<Text> ();
		healthText.text = "HEALTH: " + health;

		restartBtn = GameObject.Find ("RestartBtn").GetComponent<Button> ();
		restartText = GameObject.Find ("RestartText").GetComponent<Text> ();
		restartBtn.gameObject.SetActive (false);

		// finding spawn points
		enemySpawn = GameObject.Find ("EnemySpawn").GetComponent<Transform> ();
		enemySpawn2 = GameObject.Find ("EnemySpawn (1)").GetComponent<Transform> ();
		enemySpawn3 = GameObject.Find ("EnemySpawn (2)").GetComponent<Transform> ();
		enemySpawn4 = GameObject.Find ("EnemySpawn (3)").GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {

		// enemy spawn location and rate
		if ((Time.time > nextEnemy) && (health > 0) && (remaining > 0) && (totalDans > 0)) {
			nextEnemy = Time.time + enemyRespawnRate;

			// pick random spawn location
			int x = Random.Range (0,3);
			switch (x)
			{
			case 0:
				Instantiate (enemy, enemySpawn.position, enemySpawn.rotation);
				totalDans--;
				break;
			case 1:
				Instantiate(enemy, enemySpawn2.position, enemySpawn2.rotation);
				totalDans--;
				break;
			case 2:
				Instantiate(enemy, enemySpawn3.position, enemySpawn3.rotation);
				totalDans--;
				break;
			default: // 3 or not 0, 1, 2
				Instantiate(enemy, enemySpawn4.position, enemySpawn4.rotation);
				totalDans--;
				break;
			}
		}

		if (health == 0) {
			restartBtn.gameObject.SetActive (true);
			restartText.text = "You are not the man :(\nRestart?";
		}

		if (remaining == 0) {
			restartBtn.gameObject.SetActive (true);
			restartText.text = "You are the man :)\nPlay again?";
		}
	}
}