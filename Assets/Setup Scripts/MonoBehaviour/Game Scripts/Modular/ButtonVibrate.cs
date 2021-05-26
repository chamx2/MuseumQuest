using System.Collections;
using UnityEngine;

public class ButtonVibrate : MonoBehaviour
{

#if UNITY_IOS || UNITY_ANDROID
	public void HandleVibrate()
	{
		Handheld.Vibrate();
	}
#endif
}