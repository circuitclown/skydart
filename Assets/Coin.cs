using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D otherCollider) {
		float coinAmount = GetCoinAmount();
		GameObject.FindWithTag("PowerupStatus").GetComponent<PowerupStatus>().ShowMessage(
			"You got " + coinAmount + " coins!"
		);
		PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins", 0) + coinAmount);
	}

	float GetCoinAmount() {
		int random = Random.Range(0, 100);

		if (random < 25) {
			return 25;
		}

		if (random < 50) {
			return 50;
		}

		if (random < 70) {
			return 75;
		}

		if (random < 85) {
			return 100;
		}

		if (random < 95) {
			return 150;
		}

		return 200;
	}
}
