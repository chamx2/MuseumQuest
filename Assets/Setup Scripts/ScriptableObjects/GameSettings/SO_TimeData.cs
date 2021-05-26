using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/TimeDatas", fileName = "New Time Data")]
public class SO_TimeData : ScriptableObject
{
	public enum TimerState
	{
		start,
		end
	}

	DateTime startTime, endTime;
	TimeSpan timeSpan, totalTimeSpan;
	public TimerState state;
	public double totalTimeSpanDuration;

	void OnEnable()
	{
		state = TimerState.start;
	}

	public void StartTime()
	{
		if (state == TimerState.end)
		{
			return;
		}
		startTime = DateTime.UtcNow;
		state = TimerState.end;
	}

	public void EndTime()
	{
		if (state == TimerState.start)
		{
			return;
		}
		endTime = DateTime.UtcNow;
		state = TimerState.start;
		CalculateTimeSpan();
	}

	void CalculateTimeSpan()
	{
		double duration;
		timeSpan = endTime.Subtract(startTime);
		duration = Convert.ToDouble(timeSpan.TotalSeconds);
		totalTimeSpanDuration += duration;
		totalTimeSpan = totalTimeSpan.Add(timeSpan);
	}
	public void ResetTotalTimeSpan()
	{
		totalTimeSpanDuration = 0;
	}
}