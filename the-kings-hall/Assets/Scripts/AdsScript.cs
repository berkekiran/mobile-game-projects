using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using System.Runtime.InteropServices;

public class AdsScript : MonoBehaviour {

	public static AdsScript Instance {set; get;}

	void Start(){
		Instance = this;
	}
	public void ShowRewardedAd()
	{
		if (Advertisement.IsReady("rewardedVideo"))
		{
			var options = new ShowOptions { resultCallback = HandleShowResult };
			Advertisement.Show("rewardedVideo", options);
		}
	}
	private void HandleShowResult(ShowResult result)
	{
		GameScript.Instance.rewardPoints = 50;
	}

}
