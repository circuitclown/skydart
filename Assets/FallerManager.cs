using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallerManager : MonoBehaviour {
	public Camera mainCamera;
	public GameObject ballRedPrefab;
	public GameObject ballPurplePrefab;
	public GameObject ballGreenPrefab;
	public GameObject starPrefab;
	public GameObject bombPrefab;
	public GameObject coinPrefab;

	private float timeSinceLastDrop = 0;
	private float nextDropTime = 0.75f;
	private int droppedFallersCount = 0;
	private float dropTimeMultiple = 1;

	void FixedUpdate() {
		UpdateDrops();
	}

	void UpdateDrops() {
		timeSinceLastDrop += Time.deltaTime;

		if (timeSinceLastDrop >= nextDropTime) {
			Drop();
		}
	}

	GameObject GetFaller() {
		int random = Random.Range(0, 100);

		if (random < 33) {
			return ballRedPrefab;
		}

		if (random < 59) {
			return ballPurplePrefab;
		}

		if (random < 79) {
			return ballGreenPrefab;
		}

		if (random < 87) {
			return bombPrefab;
		}

		if (random < 95) {
			return coinPrefab;
		}


		return starPrefab;
	} 

	Vector3 GetLocation() {
		float randomViewportX = Random.value * (5f / 6f) + (1f / 12f);
		return mainCamera.ViewportToWorldPoint(new Vector3(randomViewportX, 1, -mainCamera.transform.position.z));
	}

	void Drop() {
		Instantiate(
			GetFaller(),
			GetLocation(),
			Quaternion.identity
		);

		droppedFallersCount++;
		timeSinceLastDrop = 0;

		nextDropTime = 60f * (1f / (droppedFallersCount + 40f)) * dropTimeMultiple;
	}

	public void SetDropTimeMultiple(float newDropTimeMultiple) {
		dropTimeMultiple = newDropTimeMultiple;
	}

	public void ResetDropTimeMultiple() {
		dropTimeMultiple = 1;
	}
}
