using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour {

	private float currentTime = 4.4f;
	private bool isCountingDown = true;

	void Start(){
		if (CloudVariables.ImportantValues [1] == 1) {
			AudioListener.volume = 0.0f;
		}
		else{
			AudioListener.volume = 1.0f;
		}
	}

	void Update()
	{
		if (isCountingDown)
			UpdateCounter ();
		else
			SceneManager.LoadScene("menu");
	}

	void UpdateCounter()
	{
		currentTime -= Time.deltaTime;
		if (currentTime < 0)
		{
			currentTime = 0;
			isCountingDown = false;
		}
	}

}
	