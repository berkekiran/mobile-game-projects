using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class extraName : MonoBehaviour {

	public GameObject modeName;
	float currentTime = 2f;
	bool isCountingDown = true;
	string mode1;

	void Start()
	{
		if (CloudVariables.ImportantValues[0] == 0)
			mode1 = "NORMAL GAME";
		if (CloudVariables.ImportantValues[0] == 1)
			mode1 = "SLOW SPEED";
		if (CloudVariables.ImportantValues[0] == 2)
			mode1 = "CHANGE SIZE POINTS";
		if (CloudVariables.ImportantValues[0] == 3)
			mode1 = "EXTRA LIFE";
		Text modename = modeName.GetComponent<Text>();

		modename.text = mode1;

		PlayGamesScript.Instance.SaveData ();
	}
	void Update()
	{
		if (isCountingDown)
			UpdateCounter ();
	}
	void UpdateCounter()
	{
		currentTime -= Time.deltaTime;
		if (currentTime < 0)
		{
			currentTime = 0;
			SceneManager.LoadScene("gameIn");
			isCountingDown = false;
		}
	}
}
