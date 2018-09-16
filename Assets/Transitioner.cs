using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioner : MonoBehaviour {
	public Animator animator;

	private int sceneIndex;

	public void StartTransition(int sceneIndex) {
		this.sceneIndex = sceneIndex;
		animator.SetTrigger("start-fade-out");
	} 

	public void MovePanelForward() {
		transform.SetAsLastSibling();
	}

	public void MovePanelBack() {
		transform.SetAsFirstSibling();
	}

	public void OnFadeComplete() {
		SceneManager.LoadSceneAsync(sceneIndex);
	}
}
