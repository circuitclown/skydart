using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreOwnedDart : MonoBehaviour {
	[HideInInspector]
	public int dartIndex;
	[HideInInspector]
	public StoreGrid storeGrid;
	[HideInInspector]
	public CoinsStatus coinsStatus;

	public void OnPress() {
		PlayerPrefs.SetInt("SelectedDart", dartIndex);
		storeGrid.RefreshGrid();
		coinsStatus.RefreshStatus();
	}
}
