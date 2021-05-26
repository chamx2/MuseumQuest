using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List Int Variable", order = 2, menuName = "Data type/List/Int")]
public class ListIntVariable : ScriptableObject
{
	public List<int> listInt = new List<int>();
}