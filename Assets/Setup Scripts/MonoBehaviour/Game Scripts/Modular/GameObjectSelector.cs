using UnityEngine;

public class GameObjectSelector : MonoBehaviour
{
	[SerializeField] GameObject[] objects;
	int currentIndex, index;

	public void HandleSetIndex(int index)
	{
		currentIndex = index;
	}

	public void HandleShowObject()
	{
		objects[index].SetActive(false);
		index = currentIndex;
		objects[index].SetActive(true);
	}

	public void HandleHideObjects()
	{
		objects[index].SetActive(false);
	}
}