using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour {
	public Text text;

	void Start () {
		if (Clock.isBestScore) {
			text.text = "Score:\n" + Clock.finalScore + "\nNew High Score!";
			return;
		}

		text.text = "Score:\n" + Clock.finalScore + "\nBest:\n" + Clock.currentBestScore;
	}
}
