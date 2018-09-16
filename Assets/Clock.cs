using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour {
	public Text text;
	public static float finalScore;
	public static float currentBestScore;
	public static bool isBestScore;

	private float time = 0;
	private float score = 0;

	void FixedUpdate () {
		time += Time.deltaTime;
		score += Time.deltaTime * 10;

		text.text = Mathf.Floor(score).ToString();
	}

	public void AddToScore(float amount) {
		score += amount;
	} 

	public void OnGameOver() {
		finalScore = Mathf.Floor(score);

		float savedBestScore = PlayerPrefs.GetFloat("BestScore", 0);

		if (savedBestScore < score) {
			PlayerPrefs.SetFloat("BestScore", finalScore);
			currentBestScore = finalScore;
			isBestScore = true;
			return;
		}

		currentBestScore = savedBestScore;
		isBestScore = false;

		if (!Social.localUser.authenticated) {
			Social.localUser.Authenticate(SubmitScore);
		} else {
			SubmitScore(true);
		}
	}

	void SubmitScore(bool isAuthenticated) {
		if (!isAuthenticated) {
			return;
		}

		Social.ReportScore(Convert.ToInt64(currentBestScore), "main", OnReportScore);
	}

	void OnReportScore(bool wasSuccessful) {}
}
