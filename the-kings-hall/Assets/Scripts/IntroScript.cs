using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour {

	public GameObject introUi;

	void Start () {

		if (CloudVariables.ImportantValues [0] == 1)
			AudioListener.volume = 1.0f;
		else if (CloudVariables.ImportantValues [0] == 0)
			AudioListener.volume = 0.0f;

		introUi.GetComponent<Animator> ().Play ("IntroAnim", -1, 0f);
		StartCoroutine(WaitForPassIntro());
	}

IEnumerator WaitForPassIntro()
	{
		yield return new WaitForSeconds (3.3f);
		SceneManager.LoadScene("main");
	}
}
