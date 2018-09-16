using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour {
	public float extraScoreBonus;
	public string scorePowerupMessage;
	public float launcherLaunchTimeMultiple;
	public float launcherPowerupDuration;
	public string launcherPowerupMessage;
	public float fallerManagerDropTimeMultiple;
	public float dropPowerupDuration;
	public string dropPowerupMessage;
	public string nothingMessage;

	void OnTriggerEnter2D(Collider2D otherCollider) {
		int random = Random.Range(0, 100);

		if (random < 40) {
			StartScorePowerup();
			return;
		}

		if (random < 65) {
			StartLaunchPowerup();
			Invoke("EndLaunchPowerup", launcherPowerupDuration);
			return;
		}

		if (random < 90) {
			StartDropPowerup();
			Invoke("EndDropPowerup", dropPowerupDuration);
			return;
		}

		GameObject.FindWithTag("PowerupStatus").GetComponent<PowerupStatus>().ShowMessage(nothingMessage);
	}

	void StartScorePowerup() {
		GameObject.FindWithTag("PowerupStatus").GetComponent<PowerupStatus>().ShowMessage(scorePowerupMessage);
		GameObject.FindWithTag("Clock").GetComponent<Clock>().AddToScore(extraScoreBonus);
	}

	void StartLaunchPowerup() {
		GameObject.FindWithTag("PowerupStatus").GetComponent<PowerupStatus>().ShowMessage(launcherPowerupMessage);
		GameObject.FindWithTag("Launcher").GetComponent<Launcher>().SetLaunchTimeMultiple(launcherLaunchTimeMultiple);
	}

	void StartDropPowerup() {
		GameObject.FindWithTag("PowerupStatus").GetComponent<PowerupStatus>().ShowMessage(dropPowerupMessage);
		GameObject.FindWithTag("FallerManager").GetComponent<FallerManager>().SetDropTimeMultiple(
			fallerManagerDropTimeMultiple
		);
	}

	void EndLaunchPowerup() {
		GameObject.FindWithTag("Launcher").GetComponent<Launcher>().ResetLaunchTimeMultiple();
	}

	void EndDropPowerup() {
		GameObject.FindWithTag("FallerManager").GetComponent<FallerManager>().ResetDropTimeMultiple();
	}
}
