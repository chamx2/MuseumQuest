using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IUpdateable
{
#region Fields
	[Tooltip("ScriptablObject PoolData, Drag to inspector to get reference")]
	[SerializeField] PoolData[] poolData;
	[Space()]
	[SerializeField] FloatReference spawnTimeRandom;
	[SerializeField] FloatReference spawnRate;
	[SerializeField] Transform[] spawnPosition;
	float spawnTimer;
	Camera mainCam;
	Vector2 topLeft, topRight;
#endregion

#region Unity Methods
	void Awake()
	{
		mainCam = Camera.main;
		topLeft = mainCam.ScreenToWorldPoint(new Vector2(0, Screen.height));
		topRight = mainCam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
	}

	private void OnEnable()
	{
		UpdateManager.Instance.Register(this);
	}

	void IUpdateable.OnUpdate(float time)
	{
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0.0f)
		{
			Spawn();
			ResetSpawnTimer();
		}
	}

	private void OnDisable()
	{
		UpdateManager.Instance.Unregister(this);
	}
#endregion

	public void HandleStartGame()
	{
		ResetSpawnTimer();
	}

#region Private Methods
	//Resets the spawn timer with a random offset
	void ResetSpawnTimer()
	{
		spawnTimer = (float)(spawnRate + Random.Range(0, spawnTimeRandom * 100) / 100.0);
	}

	void Spawn()
	{
		int spawnResult = Randomize(poolData.Length);
		GameObject go = poolData[spawnResult].GetPooledObject();

		int spawnNumber = Randomize(spawnPosition.Length);
		go.transform.position = spawnPosition[spawnNumber].position;
		go.SetActive(true);
	}

	int Randomize(int value)
	{
		var weights = new Dictionary<int, int>();
		int result = 100 / value;

		for (int i = 0; i < value; i++)
		{
			weights.Add(i, result);
		}

		int selected = WeightedRandomizer.From(weights).TakeOne(); // Strongly-typed object returned. No casting necessary.
		return selected;
	}

#endregion
}