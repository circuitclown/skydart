using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupStatus : MonoBehaviour {
	public Text text;
	public float changeSpeed;
	public float textDuration;

	bool isShowing = false;
	bool hasCompletedAnimating = false;
	
	void FixedUpdate () {
		if (isShowing && !hasCompletedAnimating) {
			SetAlpha(text.color.a + Time.deltaTime * changeSpeed);

			if (1 <= text.color.a) {
				SetAlpha(1);
				hasCompletedAnimating = true;
			}
		}

		if (!isShowing && !hasCompletedAnimating) {
			SetAlpha(text.color.a - Time.deltaTime * changeSpeed);

			if (text.color.a <= 0) {
				SetAlpha(0);
				hasCompletedAnimating = true;
				text.text = "";
			}
		}
	}

	public void ShowMessage(string message) {
		text.text = message;
		isShowing = true;
		hasCompletedAnimating = false;
		Invoke("HideMessage", textDuration);
	}

	void HideMessage() {
		isShowing = false;
		hasCompletedAnimating = false;
	}

	void SetAlpha(float newAlpha) {
		text.color = new Color(
			text.color.r, 
			text.color.g, 
			text.color.b, 
			newAlpha
		);
	}
}
