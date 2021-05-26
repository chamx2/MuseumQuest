using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GDataController : MonoBehaviour
{
	[SerializeField] FloatVariable answers, correctAnswers, wrongAnswers, totalAnswers, totalCorrects, totalIncorrects, totalMaxCombo;
	[SerializeField] SO_TimeData sceneTimeData;
	[SerializeField] GameData gameData;

	public void AddData()
	{
		gameData.Load();
		gameData.gameData.Add(new GameData.GDataList());
	}
	public void HandleCorrectAnswer()
	{
		answers.ApplyChange(1);
		correctAnswers.ApplyChange(1);
		totalCorrects.ApplyChange(1);
		totalAnswers.ApplyChange(1);
	}
	public void HandleWrongAnswer()
	{
		answers.ApplyChange(1);
		wrongAnswers.ApplyChange(1);
		totalIncorrects.ApplyChange(1);
		totalAnswers.ApplyChange(1);
	}
	public void ResetVariableValues()
	{
		answers.SetValue(0);
		correctAnswers.SetValue(0);
		wrongAnswers.SetValue(0);
	}
	public void ResetGameTimeDuration()
	{
		sceneTimeData.totalTimeSpanDuration = 0;
	}
}