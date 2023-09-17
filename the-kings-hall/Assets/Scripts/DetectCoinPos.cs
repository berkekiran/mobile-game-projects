using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCoinPos : MonoBehaviour {

	void OnTriggerEnter(Collider col)
	{
		
		switch(col.gameObject.name){

			case "leftsection11":
				GameScript.section = "leftsection11";	
				break;

			case "rightsection11":
				GameScript.section = "rightsection11";	
				break;

			case "leftsection21":
				GameScript.section = "leftsection21";	
				break;

			case "rightsection21":
				GameScript.section = "rightsection21";	
				break;

			case "leftsection22":
				GameScript.section = "leftsection22";	
				break;

			case "rightsection22":
				GameScript.section = "rightsection22";	
				break;

			case "leftsection41":
				GameScript.section = "leftsection41";	
				break;

			case "rightsection41":
				GameScript.section = "rightsection41";	
				break;

			case "leftsection42":
				GameScript.section = "leftsection42";	
				break;

			case "rightsection42":
				GameScript.section = "rightsection42";	
				break;

			case "leftsection43":
				GameScript.section = "leftsection43";	
				break;

			case "rightsection43":
				GameScript.section = "rightsection43";	
				break;

			case "leftsection44":
				GameScript.section = "leftsection44";	
				break;

			case "rightsection44":
				GameScript.section = "rightsection44";	
				break;

		}

	}

}
