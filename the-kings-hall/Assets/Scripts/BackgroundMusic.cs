using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
	
public class BackgroundMusic : MonoBehaviour {

	private static BackgroundMusic _instance ;

	void Awake()
	{
		if(!_instance)
			_instance = this ;
		else
			Destroy(this.gameObject) ;

		DontDestroyOnLoad(this.gameObject) ;
	}

}
