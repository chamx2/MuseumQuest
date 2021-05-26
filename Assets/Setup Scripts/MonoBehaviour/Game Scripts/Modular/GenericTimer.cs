using UnityEngine;

public class GenericTimer : MonoBehaviour, IUpdateable
{
	[SerializeField] bool shouldStart = false;
	[SerializeField] FloatReference maxTime;
	[SerializeField] FloatVariable currentTime;
	[SerializeField] GameEvent onRaise;

	private void OnEnable()
	{
		UpdateManager.Instance.Register(this);
		currentTime.SetValue(0);

		if (shouldStart)
		{
			HandleOnRaise();
		}
	}

	void IUpdateable.OnUpdate(float time)
	{
		currentTime.ApplyChange(time);

		if (currentTime.Value >= maxTime)
		{
			HandleOnRaise();
			currentTime.SetValue(0);
		}
	}

	void OnDisable()
	{
		UpdateManager.Instance.Unregister(this);
	}

	void HandleOnRaise()
	{
		if (onRaise != null)
		{
			onRaise.Raise();
		}
	}

}