using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSocialAuthenticator : MonoBehaviour {
	void Start () {
		Social.localUser.Authenticate(OnAuthenticate);
	}

	void OnAuthenticate(bool wasSuccess) {
	}
}
