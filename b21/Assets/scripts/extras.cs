using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class extras : MonoBehaviour {

	public GameObject extrasCanvas, extraUseExtraOneLife, extraSize, extraSpeed, extraBuyButton, normalGame;
	Sprite extraUseExtraOneLife0, extraUseExtraOneLife1, extraSize0, extraSize1, extraSpeed0, extraSpeed1;
	bool buyClicked = false;

	void Start()
	{
		PlayGamesScript.Instance.LoadData ();
		CloudVariables.SetImportantValues (0, 0);

		extraUseExtraOneLife0 = Resources.Load <Sprite>("extraUseExtraOneLifeN");
		extraUseExtraOneLife1 = Resources.Load <Sprite>("extraUseExtraOneLifeNormal");
		extraSize0 = Resources.Load <Sprite>("extraSizeN");
		extraSize1 = Resources.Load <Sprite>("extraSizeNormal");
		extraSpeed0 = Resources.Load <Sprite>("extraSpeedN");
		extraSpeed1 = Resources.Load <Sprite>("extraSpeedNormal");

		if (CloudVariables.ImportantValues [4] != 0) {
			extraSpeed.GetComponent<Image> ().sprite = extraSpeed1;
			extraSpeed.GetComponent<Button> ().interactable = true;
		} else {
			extraSpeed.GetComponent<Image> ().sprite = extraSpeed0;
			extraSpeed.GetComponent<Button> ().interactable = false;
		}
		if (CloudVariables.ImportantValues [5] != 0) {
			extraUseExtraOneLife.GetComponent<Image> ().sprite = extraUseExtraOneLife1;
			extraUseExtraOneLife.GetComponent<Button> ().interactable = true;
		} else {
			extraUseExtraOneLife.GetComponent<Image> ().sprite = extraUseExtraOneLife0;
			extraUseExtraOneLife.GetComponent<Button> ().interactable = false;
		}
		if (CloudVariables.ImportantValues [6] != 0) {
			extraSize.GetComponent<Image> ().sprite = extraSize1;
			extraSize.GetComponent<Button> ().interactable = true;
		} else {
			extraSize.GetComponent<Image> ().sprite = extraSize0;
			extraSize.GetComponent<Button> ().interactable = false;
		}
	}

	void Update(){
		if (extrasCanvas.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("extrasOff") &&
		   extrasCanvas.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length <
		   extrasCanvas.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime) {
			if (!extrasCanvas.GetComponent<AudioSource> ().isPlaying) {
				if (buyClicked) {
					SceneManager.LoadScene ("shop");
					buyClicked = false;
				} else
					SceneManager.LoadScene ("extraName");
			}
		}
	}

	public void extraBuyButton_Click()
	{
		buyClicked = true;
		extrasCanvas.GetComponent<Animator> ().Play ("extrasOff", -1, 0f);
	}

	public void extraUseExtraOneLife_Click(){
		if(CloudVariables.ImportantValues [5] != 0){
			CloudVariables.SetImportantValues (0, 3);
			if (CloudVariables.ImportantValues[5] == 3)
				CloudVariables.ImportantValues[5] = 2;
			else if (CloudVariables.ImportantValues[5] == 2)
				CloudVariables.ImportantValues[5] = 1;
			else
				CloudVariables.ImportantValues[5] = 0;
			PlayGamesScript.Instance.SaveData ();
			extrasCanvas.GetComponent<Animator> ().Play ("extrasOff", -1, 0f);
		}
	}

	public void extraSize_Click(){
		if (CloudVariables.ImportantValues [6] != 0) {
			CloudVariables.SetImportantValues (0, 2);
			if (CloudVariables.ImportantValues [6] == 3)
				CloudVariables.ImportantValues [6] = 2;
			else if (CloudVariables.ImportantValues [6] == 2)
				CloudVariables.ImportantValues [6] = 1;
			else
				CloudVariables.ImportantValues [6] = 0;
			PlayGamesScript.Instance.SaveData ();
			extrasCanvas.GetComponent<Animator> ().Play ("extrasOff", -1, 0f);
		}
	}

	public void extraSpeed_Click()
	{
		if (CloudVariables.ImportantValues [4] != 0) {
			CloudVariables.SetImportantValues (0, 1);
			if (CloudVariables.ImportantValues [4] == 3)
				CloudVariables.ImportantValues [4] = 2;
			else if (CloudVariables.ImportantValues [4] == 2)
				CloudVariables.ImportantValues [4] = 1;
			else
				CloudVariables.ImportantValues [4] = 0;
			PlayGamesScript.Instance.SaveData ();
			extrasCanvas.GetComponent<Animator> ().Play ("extrasOff", -1, 0f);
		}
	}

	public void normalGame_Click(){
		extrasCanvas.GetComponent<Animator> ().Play ("extrasOff", -1, 0f);
	}
}
