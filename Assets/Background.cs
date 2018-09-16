using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour {
	public float speed;
	public float saturation;
	public float value;
	public Image image;

	void FixedUpdate() {
		Color color = Color.HSVToRGB(Mathf.Repeat(Time.time * speed, 1), saturation, value);
		image.color = color;
	}
}
