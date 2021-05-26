using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles DontDestroyOnLoad API, should be attached on Gameobject
//that need not be destory on game life cycle
public class DontDestroyOnLoad : MonoBehaviour
{
	protected static GameObject instance;


	void Awake()
	{
		if(instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		}
		else
		{
			instance = this.gameObject;
		}

		DontDestroyOnLoad(this.gameObject);
	}
 
}