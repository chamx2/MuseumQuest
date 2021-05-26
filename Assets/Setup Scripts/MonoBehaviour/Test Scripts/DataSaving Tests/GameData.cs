using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "New Game Data", order = 0, menuName = "Data/Game Data")]
public class GameData : ScriptableObject
{
	[Serializable]
	public class GData
	{

	}

	[Serializable]
	public class GDataList
	{
		public List<GData> gameDataList = new List<GData>();
	}
	public List<GDataList> gameData = new List<GDataList>();
	string gameDataProjectFilePath;
	private void OnEnable()
	{
#if UNITY_ANDROID
		gameDataProjectFilePath = System.IO.Path.Combine(Application.persistentDataPath, "GameData.json");
#endif

#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_EDITOR_WIN || UNITY_STANDALONE
		gameDataProjectFilePath = Application.dataPath + "/streamingAssets/GameData.json";
#endif
	}

	public void Save()
	{
		string dataAsJson = JsonUtility.ToJson(this, true);
		string filePath = gameDataProjectFilePath;
		File.WriteAllText(filePath, dataAsJson);
	}

	public void Load()
	{
		string filePath = gameDataProjectFilePath;

		if (File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath);
			gameData[gameData.Count - 1].gameDataList = JsonHelper.FromJson<GData>(dataAsJson);
		}
	}

	public void ClearData()
	{
		gameData.Clear();

	}

	public void CreateNewGameData()
	{
		gameData.Add(new GameData.GDataList());
	}
}