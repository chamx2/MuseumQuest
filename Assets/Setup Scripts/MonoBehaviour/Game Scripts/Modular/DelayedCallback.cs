using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class DelayedCallback : MonoBehaviour
{
	[SerializeField] bool shouldInitialize = false;
	[SerializeField] float waitTime;
	[Space(), SerializeField] UnityEvent raise;
	WaitForSeconds delay;

#region Unity Methods
	void Awake()
	{
		if (waitTime > 0)
		{
			delay = new WaitForSeconds(waitTime);
		}
	}

	void Start()
	{
		if (shouldInitialize)
		{
			HandleInvoke();
		}
	}
#endregion

	public void HandleInvoke()
	{
		if (waitTime > 0)
		{
			StartCoroutine(InvokeDelayCallback());
		}
		else
		{
			HandleCallback();
		}
	}

	IEnumerator InvokeDelayCallback()
	{
		yield return delay;
		HandleCallback();
	}

	void HandleCallback()
	{
		if (raise != null)
		{
			raise.Invoke();
		}
	}
}