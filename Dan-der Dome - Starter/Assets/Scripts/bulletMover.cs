using UnityEngine;
using System.Collections;

public class bulletMover : MonoBehaviour {

	public float speed;

	private Rigidbody2D rb2D;

	void Start ()
	{
		// setting speed of bullet
		rb2D = GetComponent<Rigidbody2D> ();

		rb2D.velocity = transform.up * speed;
	}
}
