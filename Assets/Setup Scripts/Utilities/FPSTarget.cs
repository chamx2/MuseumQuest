using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSTarget : MonoBehaviour
{
	public int targetFrameRate = 30;

	void Awake()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;
	}

	void Update()
	{
		if (Application.targetFrameRate != targetFrameRate)
			Application.targetFrameRate = targetFrameRate;
	}
}