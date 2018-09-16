using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsStatus : MonoBehaviour {
	public Text text;

	void Start() {
		RefreshStatus();
	}

	public void RefreshStatus() {
		int coinsCount = (int) PlayerPrefs.GetFloat("Coins", 0);

		text.text = "You have " + coinsCount + (coinsCount == 1 ? " coin" : " coins") + "!";
	}
}
