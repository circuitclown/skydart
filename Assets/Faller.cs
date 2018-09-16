using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : MonoBehaviour {
	public Vector2 initialVelocity;
	public Rigidbody2D rigidbody2D;
	public ParticleSystem particleSystem;
	public SpriteRenderer spriteRenderer;
	public Collider2D collider2D;
	public float scoreBonus;
	public bool required;
	public string loseLifeMessage;

	void Start () {
		rigidbody2D.velocity = initialVelocity;
	}

	void FixedUpdate() {
		if (transform.position.y < Camera.main.ViewportToWorldPoint(
			new Vector3(0f, 0f, -Camera.main.transform.position.z)
		).y) {
			if (required) {
				GameObject.FindWithTag("LifeManager").GetComponent<LifeManager>().LoseLife();
				GameObject.FindWithTag("PowerupStatus").GetComponent<PowerupStatus>().ShowMessage(loseLifeMessage);
			}

			Destroy(gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider) {
		particleSystem.Play();
		spriteRenderer.enabled = false;
		collider2D.enabled = false;
		rigidbody2D.bodyType = RigidbodyType2D.Static;
		GameObject.FindWithTag("Clock").GetComponent<Clock>().AddToScore(scoreBonus);
		Invoke("DestroyThis", 5);
	}

	void DestroyThis() {
		Destroy(gameObject);
	}
}
