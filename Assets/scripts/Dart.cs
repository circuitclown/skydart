using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart : MonoBehaviour {
	public float speed;
	public Rigidbody2D rigidbody2D;

	void Start() {
		rigidbody2D.velocity = transform.up * speed;
	}

	void FixedUpdate() {
		// Destroy it if it goes out of bounds.
		if (
			transform.position.y < Camera.main.ViewportToWorldPoint(
				new Vector3(0f, 0f, -Camera.main.transform.position.z)
			).y
				|| transform.position.y > Camera.main.ViewportToWorldPoint(
					new Vector3(1f, 1f, -Camera.main.transform.position.z)
				).y
				|| transform.position.x < Camera.main.ViewportToWorldPoint(
					new Vector3(0f, 0f, -Camera.main.transform.position.z)
				).x
				|| transform.position.x > Camera.main.ViewportToWorldPoint(
					new Vector3(1f, 1f, -Camera.main.transform.position.z)
				).x
		) { 
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		Destroy(gameObject);
	}
}
