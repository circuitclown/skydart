using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour {
	public Camera mainCamera;
	public GameObject dartPrefab;
	public float dartYOffset;
	public float dartZOffset;
	public float maxAngle;
	public Sprite[] dartSprites;

	private float timeSinceLastLaunch = 0;
	private float nextLaunchTime = 0.25f;
	private int launchedDartsCount = 0;
	private float launchTimeMultiple = 1;
	private Sprite dartSprite;

	void Start() {
		transform.position = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0f, -mainCamera.transform.position.z));
		dartSprite = dartSprites[PlayerPrefs.GetInt("SelectedDart", 0)];
	}

	void FixedUpdate() {
		if (Input.GetMouseButton(0)) {
			Vector3 mouseDifference = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
			float angle = Mathf.Atan2(mouseDifference.y, mouseDifference.x) * Mathf.Rad2Deg - 90;

			if (angle < -maxAngle) {
				angle = -maxAngle;
			} 

			if (maxAngle < angle) {
				angle = maxAngle;
			} 
				
			transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		}

		UpdateLaunching();
	}

	void UpdateLaunching() {
		timeSinceLastLaunch += Time.deltaTime;

		// If they're pressing for the first time since lifting, launch immidiately.
		if (Input.GetMouseButtonDown(0)) {
			Launch();
			return;
		}

		// If not, check if it is time to launch and they are holding down.
		if (timeSinceLastLaunch >= nextLaunchTime) {
			// If they aren't shooting, update launch information anyway, but don't fire.
			if (!Input.GetMouseButton(0)) {
				SetLaunchInformation();
				return;
			}

			Launch();
		}
	}

	void Launch() {
		GameObject dart = Instantiate(
			dartPrefab, 
			new Vector3(transform.position.x, transform.position.y + dartYOffset, transform.position.z + dartZOffset),
			transform.rotation
		);
		dart.GetComponent<SpriteRenderer>().sprite = dartSprite;

		SetLaunchInformation();
	}

	void SetLaunchInformation() {
		launchedDartsCount++;
		timeSinceLastLaunch = 0;

		nextLaunchTime = 42f * (1f / (launchedDartsCount + 140f)) * launchTimeMultiple;
	}

	public void SetLaunchTimeMultiple(float newLaunchTimeMultiple) {
		launchTimeMultiple = newLaunchTimeMultiple;
	}

	public void ResetLaunchTimeMultiple() {
		launchTimeMultiple = 1f;
	}
}
