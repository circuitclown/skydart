using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreYesButton : MonoBehaviour {
	public Confirmation confirmation;
	public Modal informationModal;
	public StoreGrid storeGrid;
	public CoinsStatus coinsStatus;

	public void BuyCurrentOption() {
		PlayerPrefs.SetFloat("Coins", PlayerPrefs.GetFloat("Coins", 0) - StoreGrid.chosenUnownedPrice);
		PlayerPrefs.SetString(
			"OwnedDarts", 
			PlayerPrefs.GetString("OwnedDarts", "0") + "," + StoreGrid.chosenUnownedIndex
		);
		PlayerPrefs.SetInt("SelectedDart", StoreGrid.chosenUnownedIndex);

		confirmation.HideModal();
		informationModal.ShowModal("Purchase\nSuccessful!");
		coinsStatus.RefreshStatus();
		storeGrid.RefreshGrid();
	}
}
