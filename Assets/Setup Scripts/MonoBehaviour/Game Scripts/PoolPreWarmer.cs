using UnityEngine;

public class PoolPreWarmer : MonoBehaviour
{
	[System.Serializable]
	public class Pool
	{
		public string name;
		public PoolData poolData;
		public Transform parentObject;
	}
	[SerializeField] Pool[] pooledDatas;

	void Start()
	{
		for (int i = 0; i < pooledDatas.Length; i++)
		{
			pooledDatas[i].poolData.PreWarmPool(pooledDatas[i].parentObject);
		
		}
	}
}