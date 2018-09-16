using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreUnownedDart : MonoBehaviour {
	[HideInInspector]
	public Confirmation confirmation;
	[HideInInspector]
	public Modal informationalModal;
	[HideInInspector]
	public int dartIndex;
	[HideInInspector]
	public float dartPrice;

	public void OnPress() {
		StoreGrid.chosenUnownedIndex = dartIndex;
		StoreGrid.chosenUnownedPrice = dartPrice;

		if (PlayerPrefs.GetFloat("Coins", 0) < dartPrice) {
			informationalModal.ShowModal(
				"You do not have enough coins to buy "
					+ transform.GetChild(2).GetComponent<Text>().text
					+ "."
			);
		} else {
			confirmation.ShowModal(
				"Do you want to buy " + transform.GetChild(2).GetComponent<Text>().text
				+ " for " + StoreGrid.chosenUnownedPrice.ToString("n0") + " Coins?"
			);
		}
	}
}
