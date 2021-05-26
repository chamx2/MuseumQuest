using System;
using System.IO;
using UnityEngine;

public abstract class BaseDatabase<T> : ScriptableObject
{
	protected string gameDataProjectFilePath;

	public abstract void ResetValue();

	protected void Initialize(string fileName)
	{
#if UNITY_ANDROID
		gameDataProjectFilePath = System.IO.Path.Combine(Application.persistentDataPath, fileName);
#endif

#if UNITY_EDITOR || UNITY_EDITOR_OSX || UNITY_EDITOR_WIN || UNITY_STANDALONE
		gameDataProjectFilePath = Application.dataPath + "/streamingAssets/" + fileName;
#endif
	}

	protected void SaveToJsonFile(T data)
	{
		string dataAsJson = JsonUtility.ToJson(data, true);
		string filePath = gameDataProjectFilePath;
		File.WriteAllText(filePath, dataAsJson);
	}

	protected void EncryptSaveToJsonFile(T data)
	{
		string dataAsJson = JsonUtility.ToJson(data, true);
		string filePath = gameDataProjectFilePath;
		File.WriteAllText(filePath, SaveEncoder.Encrypt(dataAsJson));
	}

	protected void LoadJsonFile(T data)
	{
		string filePath = gameDataProjectFilePath;

		if (File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath);
			JsonUtility.FromJsonOverwrite(dataAsJson, data);
		}
		else
		{
			SaveToJsonFile(data);
		}
	}

	protected void LoadEncryptJsonFile(T data)
	{
		string filePath = gameDataProjectFilePath;
		if (File.Exists(filePath))
		{
			string dataAsJson = File.ReadAllText(filePath);
			JsonUtility.FromJsonOverwrite(SaveEncoder.Decrypt(dataAsJson), data);
		}
		else
		{
			EncryptSaveToJsonFile(data);
		}
	}

}