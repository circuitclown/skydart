using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Modal : MonoBehaviour {
	public Image image;
	public Text textText;
	public Image buttonImage;
	public float speed;
	public int shownSiblingIndex;

	bool isShowing = false;
	bool hasCompletedAnimating = false;

	void FixedUpdate() {
		if (isShowing && !hasCompletedAnimating) {
			SetAlpha(image.color.a + Time.deltaTime * speed);

			if (1 <= image.color.a) {
				SetAlpha(1);
				hasCompletedAnimating = true;
			}
		}

		if (!isShowing && !hasCompletedAnimating) {
			SetAlpha(image.color.a - Time.deltaTime * speed);

			if (image.color.a <= 0) {
				SetAlpha(0);
				hasCompletedAnimating = true;
				textText.text = "";
				transform.SetSiblingIndex(0);
			}
		}
	}

	public void ShowModal(string text) {
		textText.text = text;
		isShowing = true;
		hasCompletedAnimating = false;
		transform.SetSiblingIndex(shownSiblingIndex);
	}

	public void HideModal() {
		isShowing = false;
		hasCompletedAnimating = false;
	}

	void SetAlpha(float newAlpha) {
		image.color = new Color(
			image.color.r, 
			image.color.g, 
			image.color.b, 
			newAlpha
		);

		textText.color = new Color(
			textText.color.r, 
			textText.color.g, 
			textText.color.b, 
			newAlpha
		);

		buttonImage.color = new Color(
			buttonImage.color.r, 
			buttonImage.color.g, 
			buttonImage.color.b, 
			newAlpha
		);
	}
}
