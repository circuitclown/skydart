using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Purchasing;

public class GetCoinsButton : MonoBehaviour {
	public CoinsStatus coinsStatus;
	public Modal modal;
	public Transitioner transitioner;

	public void GoBack() {
		transitioner.StartTransition(2);
	}

	void ShowSuccessMessage() {
		modal.ShowModal("Purchase\nSuccessful!");
	}

	public void ShowFailureMessage(Product product, PurchaseFailureReason reason) {
		Debug.Log(reason);
		modal.ShowModal("Purchase Failed,\nPlease try again later!");
	}

	public void OnSuccessfulPurchase(float coinsAmount) {
		PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins", 0) + coinsAmount);
		ShowSuccessMessage();
		coinsStatus.RefreshStatus();
	}
}
