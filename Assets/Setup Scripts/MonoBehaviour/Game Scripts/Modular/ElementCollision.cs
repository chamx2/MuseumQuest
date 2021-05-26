using UnityEngine;
using UnityEngine.Events;

public class ElementCollision : Element
{

	[Header("Collision Enter")]
	[SerializeField] UnityEvent elementCollisionEnter;
	[SerializeField] UnityEvent nonElementCollisionEnter;


	private void OnCollisionEnter2D(Collision2D other)
	{
		ElementCollision e = other.gameObject.GetComponent<ElementCollision>();

		if (e != null) //Check object if there is ElementTypeTrigger
		{
			if (e.element.elementType.Contains(element)) //Check elementType list
			{
				//Invoke Event
				if (elementCollisionEnter != null) { elementCollisionEnter.Invoke(); }
			}
		}
		else //Non element type
		{
			//Invoke Event
			if (nonElementCollisionEnter != null) { nonElementCollisionEnter.Invoke(); }
		}

	}
}