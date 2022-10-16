using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudVariables : MonoBehaviour {

	// sound, bestScore, rewardPoints

	public static int[] ImportantValues = new int[2];

	public static void SetImportantValues(int index, int value){
		ImportantValues [index] = value;
	}
}
