using UnityEngine;
using UnityEngine.Events;

public class ElementTrigger : Element
{
	[Header("Trigger Enter")]
	[SerializeField] UnityEvent elementTriggerEnter;
	[SerializeField] UnityEvent nonElementTriggerEnter;
	[Header("Trigger Exit")]
	[SerializeField] UnityEvent elementTriggerExit;
	[SerializeField] UnityEvent nonElementTriggerExit;

	private void OnTriggerEnter(Collider other)
	{

		ElementTrigger e = other.gameObject.GetComponent<ElementTrigger>();

		if (e != null) //Check object if there is ElementTypeTrigger
		{
			if (e.element.elementType.Contains(element)) //Check elementType list
			{
				//Invoke Event

				if (elementTriggerEnter != null) { elementTriggerEnter.Invoke(); }
			}
		}
		else //Non element type
		{
			//Invoke Event
			if (nonElementTriggerEnter != null) { nonElementTriggerEnter.Invoke(); }
		}
	}

	private void OnTriggerExit(Collider other)
	{
		ElementTrigger e = other.gameObject.GetComponent<ElementTrigger>();

		if (e != null) //Check object if there is ElementTypeTrigger
		{
			if (e.element.elementType.Contains(element)) //Check elementType list
			{
				//Invoke Event
				if (elementTriggerExit != null) { elementTriggerExit.Invoke(); }
			}
		}
		else //Non element type
		{
			//Invoke Event
			if (nonElementTriggerExit != null) { nonElementTriggerExit.Invoke(); }
		}
	}

}