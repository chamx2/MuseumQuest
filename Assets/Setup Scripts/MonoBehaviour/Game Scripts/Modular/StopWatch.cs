using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopWatch : MonoBehaviour, IUpdateable
{
	[SerializeField] FloatVariable timer;
	float seconds, minutes, hours;
	bool start;

#region Unity Methods
	void OnEnable()
	{
		UpdateManager.Instance.Register(this);

		start = false;
		timer.SetValue(0);
	}

	void IUpdateable.OnUpdate(float time)
	{
		if (start)
		{
			timer.ApplyChange(time);
			seconds = (int)(timer.Value % 60);
			minutes = (int)(timer.Value / 60 % 60);
			hours = (int)(timer.Value / 3600);
		}
	}

	void OnDisable()
	{
		UpdateManager.Instance.Unregister(this);
	}
#endregion

	public void StartTimer()
	{
		start = true;
	}

	public void StopTimer()
	{
		start = false;
	}

	public void ResetTimer()
	{
		start = false;
		timer.SetValue(0);
	}

}