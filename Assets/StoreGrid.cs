using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreGrid : MonoBehaviour {
	public GameObject selectedDartPrefab;
	public GameObject ownedDartPrefab;
	public GameObject unownedDartPrefab;
	public string[] dartNames;
	public float[] dartPrices;
	public Sprite[] dartSprites;
	public Confirmation confirmation;
	public Modal informationalModal;
	public CoinsStatus coinsStatus;
	public GridLayoutGroup gridLayoutGroup;
	public RectTransform rectTransform;

	[HideInInspector]
	public static float chosenUnownedPrice;
	[HideInInspector]
	public static int chosenUnownedIndex;

	void Start() {
		RefreshGrid();
	} 

	public void RefreshGrid() {
		int cellWidth = (Screen.width - 150) / 3;
		int cellHeight = (int) ((3f / 2f) * cellWidth);
		gridLayoutGroup.cellSize = new Vector2(cellWidth, cellHeight);
		rectTransform.sizeDelta = new Vector2(
			rectTransform.sizeDelta.x, 
			(cellHeight + 40) * Mathf.Ceil(dartNames.Length / 3f) + 50
		);
		rectTransform.anchoredPosition = new Vector2(
			rectTransform.anchoredPosition.x, 
			-rectTransform.sizeDelta.y / 2
		);

		for (int i = transform.childCount - 1; -1 < i; i--) {
			Destroy(transform.GetChild(i).gameObject);
		}

		int selectedDartIndex = PlayerPrefs.GetInt("SelectedDart", 0);
		string[] ownedDartIndexStrings = PlayerPrefs.GetString("OwnedDarts", "0").Split(',');
		int[] ownedDartIndexes = new int[ownedDartIndexStrings.Length];

		for (int i = 0; i < ownedDartIndexStrings.Length; i++) {
			ownedDartIndexes[i] = int.Parse(ownedDartIndexStrings[i]);
		}

		GameObject selectedDart = Instantiate(selectedDartPrefab, transform);
		selectedDart.transform.GetChild(2).GetComponent<Text>().text = dartNames[selectedDartIndex];
		selectedDart.transform.GetChild(1).GetComponent<Image>().sprite = dartSprites[selectedDartIndex];

		for (int i = 0; i < ownedDartIndexes.Length; i++) {
			int ownedDartIndex = ownedDartIndexes[i];

			if (ownedDartIndex == selectedDartIndex) {
				continue;
			}

			GameObject ownedDart = Instantiate(ownedDartPrefab, transform);
			ownedDart.transform.GetChild(2).GetComponent<Text>().text = dartNames[ownedDartIndex];
			ownedDart.transform.GetChild(1).GetComponent<Image>().sprite = dartSprites[ownedDartIndex];
			ownedDart.GetComponent<StoreOwnedDart>().dartIndex = ownedDartIndex;
			ownedDart.GetComponent<StoreOwnedDart>().coinsStatus = coinsStatus;
			ownedDart.GetComponent<StoreOwnedDart>().storeGrid = GetComponent<StoreGrid>();
		}

		for (int i = 0; i < dartNames.Length; i++) {
			if (checkOwnedDartIndexesContains(ownedDartIndexes, i)) {
				continue;
			}

			GameObject unownedDart = Instantiate(unownedDartPrefab, transform);
			unownedDart.transform.GetChild(2).GetComponent<Text>().text = dartNames[i];
			unownedDart.transform.GetChild(1).GetComponent<Image>().sprite = dartSprites[i];
			unownedDart.transform.GetChild(3).GetComponent<Text>().text = CreatePriceString(dartPrices[i]);
			unownedDart.GetComponent<StoreUnownedDart>().confirmation = confirmation;
			unownedDart.GetComponent<StoreUnownedDart>().informationalModal = informationalModal;
			unownedDart.GetComponent<StoreUnownedDart>().dartIndex = i;
			unownedDart.GetComponent<StoreUnownedDart>().dartPrice = dartPrices[i];
		}
	}

	string CreatePriceString(float price) {
		return price.ToString("n0") + " Coins";
	}

	bool checkOwnedDartIndexesContains(int[] ownedDartIndexes, int index) {
		for (int i = 0; i < ownedDartIndexes.Length; i++) {
			if (ownedDartIndexes[i] == index) {
				return true;
			}
		}

		return false;
	}
}
