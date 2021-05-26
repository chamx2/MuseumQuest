using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New List String Variable", order = 1, menuName = "Data type/List/String")]
public class ListStringVariable : ScriptableObject
{
	public List<string> listString = new List<string>();
}