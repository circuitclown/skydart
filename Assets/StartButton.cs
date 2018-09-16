using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {
	public Transitioner transitioner;
	public Modal modal;

	public void PlayGame() {
		transitioner.StartTransition(1);
	}

	public void ShowLeaderboard() {
		if (Social.localUser.authenticated) {
			OnAuthenticate(true);
		} else {
			Social.localUser.Authenticate(OnAuthenticate);
		}
	}

	public void OnAuthenticate(bool isAuthenticated) {
		if (isAuthenticated) {
			Social.ShowLeaderboardUI();
			return;
		}

		modal.ShowModal("The leaderboard could not be loaded. Please try again later.");
	}

	public void ShowStore() {
		transitioner.StartTransition(4);
	}

	public void ShowPurchases() {
		transitioner.StartTransition(3);
	}
}
