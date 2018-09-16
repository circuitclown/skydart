using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour {
	public string hitMessage;

	void OnTriggerEnter2D(Collider2D otherCollider) {
		GameObject.FindWithTag("LifeManager").GetComponent<LifeManager>().LoseLife();
		GameObject.FindWithTag("PowerupStatus").GetComponent<PowerupStatus>().ShowMessage(hitMessage);	
	}
}
