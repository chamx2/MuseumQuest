using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu]
public class ElementType : ScriptableObject
{
	//Elements interact can interact with this Element type
	public List<ElementType> elementType = new List<ElementType>();
}