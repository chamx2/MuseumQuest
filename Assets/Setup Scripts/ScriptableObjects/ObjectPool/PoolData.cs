using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PoolData : ScriptableObject
{
	public GameObject pooledObject;
	public int pooledAmount;
	public bool willGrow;
	List<GameObject> pooledObjects;
	Transform parentObj;

	private void OnDestroy()
	{
		pooledObjects = null;
	}

	public void PreWarmPool(Transform parentObj)
	{
		this.parentObj = parentObj;

		pooledObjects = new List<GameObject>();

		for (int i = 0; i < pooledAmount; i++)
		{
			CreatePooledObject(parentObj);
		}
	}

	public GameObject GetPooledObject()
	{
		for (int i = 0; i < pooledObjects.Count; i++)
		{
			if (!pooledObjects[i].activeInHierarchy)
			{
				return pooledObjects[i];
			}
		}
		if (willGrow)
		{
			return CreatePooledObject(parentObj, true);
		}

		return null;
	}

	GameObject CreatePooledObject(Transform parentObj, bool state = false)
	{
		GameObject obj = (GameObject)Instantiate(pooledObject);
		obj.transform.SetParent(parentObj);
		obj.SetActive(state);
		pooledObjects.Add(obj);
		return obj;
	}
}