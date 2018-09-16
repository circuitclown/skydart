using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class LifeManager : MonoBehaviour {
	public GameObject[] heartGameObjects;
	public Transitioner transitioner;
	public int maximumGamesWithoutAd;
	int usedLives = 0;

	public void LoseLife() {
		GetLastUnusedHeartImage().enabled = false;
		usedLives++;

		if (heartGameObjects.Length <= usedLives) {
			GameObject.FindWithTag("Clock").GetComponent<Clock>().OnGameOver();
			transitioner.StartTransition(2);
			MaybeShowAd();
		}
	}

	public void GainLife() {
		GetLastUnusedHeartImage().enabled = true;
		usedLives--;
	}

	Image GetLastUnusedHeartImage() {
		return heartGameObjects[heartGameObjects.Length - 1 - usedLives].GetComponent<Image>();
	}

	void MaybeShowAd() {
		int gamesWithoutAd = PlayerPrefs.GetInt("GamesWithoutAd");

		if (maximumGamesWithoutAd <= gamesWithoutAd) {
			Advertisement.Show("video", new ShowOptions { resultCallback = HandleAdResult });
			return;
		}

		PlayerPrefs.SetInt("GamesWithoutAd", PlayerPrefs.GetInt("GamesWithoutAd", 0) + 1);
	}

	void HandleAdResult(ShowResult result) {
		switch (result) {
		case ShowResult.Finished:
			PlayerPrefs.SetInt("GamesWithoutAd", 0);
			break;
		case ShowResult.Skipped:
			PlayerPrefs.SetInt("GamesWithoutAd", 0);
			break;
		case ShowResult.Failed:
			PlayerPrefs.SetInt("GamesWithoutAd", PlayerPrefs.GetInt("GamesWithoutAd", 0) + 1);
			break;
		}
	}
}
