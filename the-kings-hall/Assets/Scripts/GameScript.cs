using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TwitterKit.Unity;
using System.Runtime.InteropServices;

public class GameScript : MonoBehaviour {

	public static string section;
	public int sectionCount, scoreInt = 0, spawnIndex, lifepoints = 3, scoreUiscoreInt = 0, rewardPoints = 0;
	public GameObject coinSpawners, king, wallwood, floorpart, book, paper, candle, winebottle, fpsCounterGo, Camera, coin, coinIn, thanksUi, targetUi, subtitlesUi, subtitlesBack, menuUi, gameUi, scoreUi, sections, soundon, soundoff, soundonmenu, soundoffmenu, leftsection11, rightsection11, leftsection21, rightsection21, leftsection22, rightsection22, leftsection41, rightsection41, leftsection42, rightsection42, leftsection43, rightsection43, leftsection44, rightsection44;
	public Image leftbutton, rightbutton, leftbutton1, rightbutton1, leftbutton2, rightbutton2, leftbutton3, rightbutton3, leftbutton4, rightbutton4;
	public Text score, life, scoreUiscore, scoreUibestscore, subtitlesText, targetPoint, thanksText, fpsCounter;
	public bool fpsCounterStatus = false, subtitlesOn = false, reward = false, controlGame = true, introOn = false, controlScore = false, gameoff = false, scoreoff = false, coinDestroyed = false, zerolife = true, clickControl = true, coinSpawned = false, thanksoff = false;
	public Transform[] spawnPoints;
	public string[] thanksTexts;
	float deltaTime = 0.0f;
	public string[] Numbers = new string[4] {"1","2","3","4"};
	public string  startCounter = "1", nTnumber;

	public static GameScript Instance { get; private set; }

	void SpawnCoin () {
		StartCoroutine(WaitForCoinSpawn());
	}
		
	IEnumerator WaitForCoinSpawn()
	{
		if (coinDestroyed) {
			yield return new WaitForSeconds (0.5f);
			spawnIndex = Random.Range (0, spawnPoints.Length);
			coin.GetComponent<Transform> ().localPosition = new Vector3 (spawnPoints [spawnIndex].position.x, 0f, spawnPoints [spawnIndex].position.z);
			coin.GetComponent<Animator> ().Play ("CoinSpawn", -1, 0f);
			coinSpawners.GetComponent<AudioSource> ().Play ();
			coinDestroyed = false;
			coinSpawned = true;
		}
	}
	IEnumerator WaitForOpenSubtitles()
	{
		if(subtitlesOn){		
			yield return new WaitForSeconds (1.5f);
			subtitlesUi.SetActive (true);
			subtitlesText.text = "Welcome to my hall.";
			subtitlesUi.GetComponent<Animator> ().Play ("SubtitlesOn", -1, 0f);
			subtitlesOn = false;
		}
	}

	void Start () {

		Instance = this;

		rewardPoints = 0;

		thanksTexts = new string[] {"Well done!", "Great!", "Good job!", "WOW!", "Eagle Eye!", "Coin Hunter!", "Impressive!", "What!", "How!"};
		Camera.GetComponent<Animator> ().Play ("CameraStart", -1, 0f);
		menuUi.GetComponent<Animator> ().Play ("MenuOn", -1, 0f);
		subtitlesOn = true;
		StartCoroutine(WaitForOpenSubtitles());

		PlayGamesScript.Instance.LoadData();

		scoreUiscoreInt = CloudVariables.ImportantValues [1];
		scoreUibestscore.text = "Best Score: " + CloudVariables.ImportantValues [1].ToString ();

		if (CloudVariables.ImportantValues [0] == 1) {
			AudioListener.volume = 1.0f;
			soundoffmenu.GetComponent<Text> ().enabled = false;
			soundonmenu.GetComponent<Text> ().enabled = true;
			soundoff.GetComponent<Text> ().enabled = false;
			soundon.GetComponent<Text> ().enabled = true;
		} else if (CloudVariables.ImportantValues [0] == 0){
			AudioListener.volume = 0.0f;
			soundoffmenu.GetComponent<Text> ().enabled = true;
			soundonmenu.GetComponent<Text> ().enabled = false;
			soundoff.GetComponent<Text> ().enabled = true;
			soundon.GetComponent<Text> ().enabled = false;
		}

		score.text = scoreInt.ToString ();

	}

	void Update() {

		if(fpsCounterGo.activeSelf){
			deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
			float fps = 1.0f / deltaTime;
			fpsCounter.text = Mathf.FloorToInt(fps).ToString ();
		}

		if (controlGame) {

			if (sectionCount == 0) {
				lifepoints = 3;
				life.text = lifepoints.ToString () + " life points left";

				/*
					//default visibility sections
					leftsection11.SetActive (false);
					rightsection11.SetActive (false);
					leftsection21.SetActive (false);
					rightsection21.SetActive (false);
					leftsection22.SetActive (false);
					rightsection22.SetActive (false);
					leftsection41.SetActive (false);
					rightsection41.SetActive (false);
					leftsection42.SetActive (false);
					rightsection42.SetActive (false);
					leftsection43.SetActive (false);
					rightsection43.SetActive (false);
					leftsection44.SetActive (false);
					rightsection44.SetActive (false);
				*/

				//default visibility ui elements
				leftbutton1.enabled = false;
				leftbutton1.GetComponentInChildren<Text> ().enabled = false;
				rightbutton1.enabled = false;
				rightbutton1.GetComponentInChildren<Text> ().enabled = false;
				leftbutton2.enabled = false;
				leftbutton2.GetComponentInChildren<Text> ().enabled = false;
				rightbutton2.enabled = false;
				rightbutton2.GetComponentInChildren<Text> ().enabled = false;
				leftbutton3.enabled = false;
				leftbutton3.GetComponentInChildren<Text> ().enabled = false;
				rightbutton3.enabled = false;
				rightbutton3.GetComponentInChildren<Text> ().enabled = false;
				leftbutton4.enabled = false;
				leftbutton4.GetComponentInChildren<Text> ().enabled = false;
				rightbutton4.enabled = false;
				rightbutton4.GetComponentInChildren<Text> ().enabled = false;

			} else if (sectionCount == 1) {
				leftsection11.SetActive (true);
				rightsection11.SetActive (true);
				leftsection21.SetActive (false);
				rightsection21.SetActive (false);
				leftsection22.SetActive (false);
				rightsection22.SetActive (false);
				leftsection41.SetActive (false);
				rightsection41.SetActive (false);
				leftsection42.SetActive (false);
				rightsection42.SetActive (false);
				leftsection43.SetActive (false);
				rightsection43.SetActive (false);
				leftsection44.SetActive (false);
				rightsection44.SetActive (false);

				leftbutton1.enabled = false;
				leftbutton1.GetComponentInChildren<Text> ().enabled = false;
				rightbutton1.enabled = false;
				rightbutton1.GetComponentInChildren<Text> ().enabled = false;
				leftbutton2.enabled = false;
				leftbutton2.GetComponentInChildren<Text> ().enabled = false;
				rightbutton2.enabled = false;
				rightbutton2.GetComponentInChildren<Text> ().enabled = false;
				leftbutton3.enabled = false;
				leftbutton3.GetComponentInChildren<Text> ().enabled = false;
				rightbutton3.enabled = false;
				rightbutton3.GetComponentInChildren<Text> ().enabled = false;
				leftbutton4.enabled = false;
				leftbutton4.GetComponentInChildren<Text> ().enabled = false;
				rightbutton4.enabled = false;
				rightbutton4.GetComponentInChildren<Text> ().enabled = false;
			} else if (sectionCount == 2) {
				leftsection11.SetActive (false);
				rightsection11.SetActive (false);
				leftsection21.SetActive (true);
				rightsection21.SetActive (true);
				leftsection22.SetActive (true);
				rightsection22.SetActive (true);
				leftsection41.SetActive (false);
				rightsection41.SetActive (false);
				leftsection42.SetActive (false);
				rightsection42.SetActive (false);
				leftsection43.SetActive (false);
				rightsection43.SetActive (false);
				leftsection44.SetActive (false);
				rightsection44.SetActive (false);

				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;

				leftbutton1.enabled = true;
				leftbutton1.GetComponentInChildren<Text> ().enabled = true;
				rightbutton1.enabled = true;
				rightbutton1.GetComponentInChildren<Text> ().enabled = true;
				leftbutton2.enabled = true;
				leftbutton2.GetComponentInChildren<Text> ().enabled = true;
				rightbutton2.enabled = true;
				rightbutton2.GetComponentInChildren<Text> ().enabled = true;
				leftbutton3.enabled = false;
				leftbutton3.GetComponentInChildren<Text> ().enabled = false;
				rightbutton3.enabled = false;
				rightbutton3.GetComponentInChildren<Text> ().enabled = false;
				leftbutton4.enabled = false;
				leftbutton4.GetComponentInChildren<Text> ().enabled = false;
				rightbutton4.enabled = false;
				rightbutton4.GetComponentInChildren<Text> ().enabled = false;
			} else if (sectionCount == 4) {
				leftsection11.SetActive (false);
				rightsection11.SetActive (false);
				leftsection21.SetActive (false);
				rightsection21.SetActive (false);
				leftsection22.SetActive (false);
				rightsection22.SetActive (false);
				leftsection41.SetActive (true);
				rightsection41.SetActive (true);
				leftsection42.SetActive (true);
				rightsection42.SetActive (true);
				leftsection43.SetActive (true);
				rightsection43.SetActive (true);
				leftsection44.SetActive (true);
				rightsection44.SetActive (true);

				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;

				leftbutton1.enabled = true;
				leftbutton1.GetComponentInChildren<Text> ().enabled = true;
				rightbutton1.enabled = true;
				rightbutton1.GetComponentInChildren<Text> ().enabled = true;
				leftbutton2.enabled = true;
				leftbutton2.GetComponentInChildren<Text> ().enabled = true;
				rightbutton2.enabled = true;
				rightbutton2.GetComponentInChildren<Text> ().enabled = true;
				leftbutton3.enabled = true;
				leftbutton3.GetComponentInChildren<Text> ().enabled = true;
				rightbutton3.enabled = true;
				rightbutton3.GetComponentInChildren<Text> ().enabled = true;
				leftbutton4.enabled = true;
				leftbutton4.GetComponentInChildren<Text> ().enabled = true;
				rightbutton4.enabled = true;
				rightbutton4.GetComponentInChildren<Text> ().enabled = true;
			}
			controlGame = false;
		}
			
		if (controlScore) {
			sections.GetComponent<Animator> ().Play ("SectionOn", -1, 0f);
			gameUi.GetComponent<Animator> ().Play ("GetScore", -1, 0f);

			if (scoreInt < 10)
				targetPoint.text = "Next Target Point: 10";
			else if (scoreInt < 25)
				targetPoint.text = "Next Target Point: 25";
			else if (scoreInt < 50)
				targetPoint.text = "Next Target Point: 50";
			else if (scoreInt < 100)
				targetPoint.text = "Next Target Point: 100";
			else if (scoreInt < 150)
				targetPoint.text = "Next Target Point: 150";
			else if (scoreInt < 200)
				targetPoint.text = "Next Target Point: 200";
			else if (scoreInt < 250)
				targetPoint.text = "Next Target Point: 250";
			else if (scoreInt < 500)
				targetPoint.text = "Next Target Point: 500";
			else if (scoreInt < 750)
				targetPoint.text = "Next Target Point: 750";
			else if (scoreInt < 1000)
				targetPoint.text = "Next Target Point: 1000";

			if (scoreInt >= 0 && scoreInt < 100)
				sectionCount = 1;

			if (scoreInt >= 100 && scoreInt < 250)
				sectionCount = 2;

			if (scoreInt >= 250)
				sectionCount = 4;

			if(scoreInt >= 100)
				PlayGamesScript.UnlockAchievement(GPGSIds.achievement_a_warrior);

			if(scoreInt >= 250)
				PlayGamesScript.UnlockAchievement(GPGSIds.achievement_a_lord);
			
			if(scoreInt >= 500)
				PlayGamesScript.UnlockAchievement(GPGSIds.achievement_the_king);
			
			controlGame = true;
			coin.GetComponent<Animator> ().Play ("CoinDestroy", -1, 0f);
			coinDestroyed = true;
			SpawnCoin ();
			controlScore = false;
		}

		if (lifepoints < 1 && zerolife) {
			scoreUiscore.text = scoreInt.ToString ();
			if (scoreInt > scoreUiscoreInt) {
				scoreUiscoreInt = scoreInt;
				scoreUibestscore.text = "Best Score: " + scoreUiscoreInt.ToString ();
				CloudVariables.SetImportantValues(1, scoreUiscoreInt);
				PlayGamesScript.AddScoreToLeaderboard (GPGSIds.leaderboard_leaderboards, CloudVariables.ImportantValues[1]);
				PlayGamesScript.Instance.SaveData ();
			}
			controlGame = true;
			sectionCount = 0;
			menuUi.SetActive (false);
			targetUi.GetComponent<Animator> ().Play ("TargetOff", -1, 0f);
			gameUi.SetActive (false);
			scoreUi.SetActive (true);
			coin.GetComponent<Animator> ().Play ("CoinDestroy", -1, 0f);
			coinDestroyed = true;
			sections.GetComponent<Animator> ().Play ("SectionOff", -1, 0f);
			Camera.GetComponent<Animator> ().Play ("CameraMoveToMenu", -1, 0f);
			nTnumber = Numbers [Random.Range (0, Numbers.Length)];
			if (startCounter == nTnumber)
				reward = true;
			else
				reward = false;
			if (reward)
				AdsScript.Instance.ShowRewardedAd ();
			scoreUi.GetComponent<Animator> ().Play ("ScoreOn", -1, 0f);
			scoreUiscore.GetComponent<AudioSource>().Play();
			zerolife = false;
		}

		if (thanksoff) {
			if (thanksUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("ThanksOpen") &&
				thanksUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length <
				thanksUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime) {
				thanksUi.SetActive (false);
				thanksoff = false;
			}
		}

		if (gameoff) {
			if (gameUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("GameOff") &&
				gameUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length <
				gameUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime) {
					targetUi.SetActive (false);
					gameUi.SetActive (false);
					menuUi.SetActive (true);
					gameoff = false;
			}
		}

		if (coinSpawned) {
			if (coin.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("CoinSpawn") &&
				coin.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length <
				coin.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime) {
				clickControl = true;
				if (sectionCount == 1) {
					leftbutton.GetComponent<Button> ().interactable = true;
					rightbutton.GetComponent<Button> ().interactable = true;
				} else {
					leftbutton1.GetComponent<Button> ().interactable = true;
					rightbutton1.GetComponent<Button> ().interactable = true;
					leftbutton2.GetComponent<Button> ().interactable = true;
					rightbutton2.GetComponent<Button> ().interactable = true;
					leftbutton3.GetComponent<Button> ().interactable = true;
					rightbutton3.GetComponent<Button> ().interactable = true;
					leftbutton4.GetComponent<Button> ().interactable = true;
					rightbutton4.GetComponent<Button> ().interactable = true;
				}
				coinSpawned = false;
			}
		}


		if (scoreoff) {
			if (scoreUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).IsName ("ScoreOff") &&
				scoreUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).length <
				scoreUi.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0).normalizedTime) {
				scoreUi.SetActive (false);
				sectionCount = 0;
				scoreInt = 0 + rewardPoints;
				score.text = scoreInt.ToString ();
				controlGame = true;
				sectionCount = 1;
				gameUi.SetActive (true);
				targetUi.SetActive (true);
				gameUi.GetComponent<Animator> ().Play ("GameOn", -1, 0f);
				targetUi.GetComponent<Animator> ().Play ("TargetOn", -1, 0f);
				sections.GetComponent<Animator> ().Play ("SectionOn", -1, 0f);
				SpawnCoin ();
				scoreoff = false;
			}
		}

	}

	public void soundButtonClick () {
		if (CloudVariables.ImportantValues[0] == 1) {
			AudioListener.volume = 0.0f;
			soundoffmenu.GetComponent<Text> ().enabled = true;
			soundonmenu.GetComponent<Text> ().enabled = false;
			soundoff.GetComponent<Text> ().enabled = true;
			soundon.GetComponent<Text> ().enabled = false;
			if (menuUi.activeSelf) {
				menuUi.GetComponent<Animator> ().Play ("SoundOff", -1, 0f);
			}
			if (gameUi.activeSelf) {
				gameUi.GetComponent<Animator> ().Play ("SoundOffGame", -1, 0f);
			}
			CloudVariables.SetImportantValues(0, 0);
			PlayGamesScript.Instance.SaveData ();
		} else if (CloudVariables.ImportantValues[0] == 0) {
			AudioListener.volume = 1.0f;
			soundoffmenu.GetComponent<Text> ().enabled = false;
			soundonmenu.GetComponent<Text> ().enabled = true;
			soundoff.GetComponent<Text> ().enabled = false;
			soundon.GetComponent<Text> ().enabled = true;
			if (menuUi.activeSelf) {
				menuUi.GetComponent<Animator> ().Play ("SoundOn", -1, 0f);
			}
			if (gameUi.activeSelf) {
				gameUi.GetComponent<Animator> ().Play ("SoundOnGame", -1, 0f);
			}
			CloudVariables.SetImportantValues(0, 1);
			PlayGamesScript.Instance.SaveData ();
		}
	}

	public void leftButtonClick () {
		if (sectionCount == 1 && section == "leftsection11") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void rightButtonClick () {
		if (sectionCount == 1 && section == "rightsection11") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void leftButton1Click () {
		if (sectionCount == 2 && section == "leftsection21") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else if (sectionCount == 4 && section == "leftsection41") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void rightButton1Click () {
		if (sectionCount == 2 && section == "rightsection21") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else if (sectionCount == 4 && section == "rightsection41") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void leftButton2Click () {
		if (sectionCount == 2 && section == "leftsection22") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else if (sectionCount == 4 && section == "leftsection42") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void rightButton2Click () {
		if (sectionCount == 2 && section == "rightsection22") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else if (sectionCount == 4 && section == "rightsection42") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void leftButton3Click () {
		if (sectionCount == 4 && section == "leftsection43") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void rightButton3Click () {
		if (sectionCount == 4 && section == "rightsection43") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void leftButton4Click () {
		if (sectionCount == 4 && section == "leftsection44") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString () + " life points left";
			zerolife = true;
		}

	}

	public void rightButton4Click () {
		if (sectionCount == 4 && section == "rightsection44") {
			if (clickControl) {
				scoreInt += 5;
				score.text = scoreInt.ToString ();
				score.GetComponent<AudioSource> ().Play ();
				thanksText.text = thanksTexts[Random.Range (0, thanksTexts.Length)];
				thanksUi.SetActive (true);
				thanksUi.GetComponent<Animator> ().Play ("ThanksOpen", -1, 0f);
				thanksoff = true;
				controlScore = true;
				clickControl = false;
				leftbutton.GetComponent<Button> ().interactable = false;
				rightbutton.GetComponent<Button> ().interactable = false;
				leftbutton1.GetComponent<Button> ().interactable = false;
				rightbutton1.GetComponent<Button> ().interactable = false;
				leftbutton2.GetComponent<Button> ().interactable = false;
				rightbutton2.GetComponent<Button> ().interactable = false;
				leftbutton3.GetComponent<Button> ().interactable = false;
				rightbutton3.GetComponent<Button> ().interactable = false;
				leftbutton4.GetComponent<Button> ().interactable = false;
				rightbutton4.GetComponent<Button> ().interactable = false;
			}
		} else {
			gameUi.GetComponent<Animator> ().Play ("LifeLost", -1, 0f);
			life.GetComponent<AudioSource> ().Play ();
			lifepoints -= 1;
			life.text = lifepoints.ToString() + " life points left";
			zerolife = true;
		}

	}

	public void PlayClick () {
		controlGame = true;
		sectionCount = 1;
		menuUi.SetActive (false);
		gameUi.SetActive (true);
		targetPoint.text = "Next Target Point: 10";
		gameUi.GetComponent<Animator> ().Play ("GameOn", -1, 0f);
		targetUi.SetActive (true);
		targetUi.GetComponent<Animator> ().Play ("TargetOn", -1, 0f);
		sections.GetComponent<Animator> ().Play ("SectionOn", -1, 0f);
		coinDestroyed = true;
		SpawnCoin ();
	}

	public void MenuClick () {
		controlGame = true;
		sectionCount = 0;
		coin.GetComponent<Animator> ().Play ("CoinDestroy", -1, 0f);
		coinDestroyed = true;
		score.text = scoreInt.ToString ();
		sections.GetComponent<Animator> ().Play ("SectionOff", -1, 0f);
		targetUi.GetComponent<Animator> ().Play ("TargetOff", -1, 0f);
		gameUi.GetComponent<Animator> ().Play ("GameOff", -1, 0f);
		gameoff = true;
		scoreInt = 0 + rewardPoints;
		score.text = scoreInt.ToString ();
	}

	public void startLogin() {
		UnityEngine.Debug.Log ("startLogin()");
		Twitter.Init ();

		Twitter.LogIn (LoginCompleteWithCompose, (ApiError error) => {
			UnityEngine.Debug.Log (error.message);
		});
	}

	public void LoginCompleteWithEmail (TwitterSession session) {
		UnityEngine.Debug.Log ("LoginCompleteWithEmail()");
		Twitter.RequestEmail (session, RequestEmailComplete, (ApiError error) => { UnityEngine.Debug.Log (error.message); });
	}

	public void RequestEmailComplete (string email) {
		UnityEngine.Debug.Log ("email=" + email);
		LoginCompleteWithCompose ( Twitter.Session );
	}

	public void LoginCompleteWithCompose(TwitterSession session) {
		Twitter.Compose (session, "", "The King's Hall - My new high score is " + CloudVariables.ImportantValues[1].ToString() + ". ",new string[]{""},
			(string tweetId) => { UnityEngine.Debug.Log ("Tweet Success, tweetId=" + tweetId); },
			(ApiError error) => { UnityEngine.Debug.Log ("Tweet Failed " + error.message); },
			() => { Debug.Log ("Compose cancelled"); }
		);
	}

	public void HomeClick () {
		targetPoint.text = "Next Target Point: 10";
		if(!reward)
			rewardPoints = 0;
		scoreUi.GetComponent<Animator> ().Play ("ScoreOff", -1, 0f);
		scoreoff = true;
	}

	public void LeaderboardsClick () {
		PlayGamesScript.ShowLeaderboardsUI ();
	}

	public void AchievementsClick () {
		PlayGamesScript.ShowAchievementsUI ();
	}

	public void FpsCounterClick(){
		if(fpsCounterStatus){
			fpsCounterGo.SetActive(false);
			fpsCounterStatus = false;
		}
		else if(!fpsCounterStatus){
			fpsCounterGo.SetActive(true);
			fpsCounterStatus = true;
		}
	}

	public void SetLow() {
		king.SetActive(false);
		wallwood.SetActive(false); 
		floorpart.SetActive(false); 
		book.SetActive(false); 
		paper.SetActive(false); 
		candle.SetActive(false); 
		winebottle.SetActive(false);
	}

	public void SetHigh() {
		king.SetActive(true);
		wallwood.SetActive(true); 
		floorpart.SetActive(true); 
		book.SetActive(true); 
		paper.SetActive(true); 
		candle.SetActive(true); 
		winebottle.SetActive(true);
	}
}
