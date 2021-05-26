using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
	[System.Serializable]
	public class OnSetHealth : UnityEvent<float> { }
	[SerializeField] FloatReference maxHitPoints;
	[Space()]
	[SerializeField] OnSetHealth onHealthSet;
	[SerializeField] UnityEvent onDied, onTakeDamage, onGainHealth;
	float currentInvulnerableTime;
	float invulenrabilityTime = 0f;
	public float currentHitPoints { get; private set; }
	public bool invulnerability { get; set; }

#region Unity Methods
	void OnEnable()
	{
		ResetDamage();
	}

	void Update()
	{
		if (invulnerability)
		{
			currentInvulnerableTime += Time.deltaTime;

			if (currentInvulnerableTime >= invulenrabilityTime)
			{
				currentInvulnerableTime = 0;
				invulnerability = false;
			}
		}
	}
#endregion

	void ResetDamage()
	{
		currentHitPoints = maxHitPoints;
		invulnerability = false;
		onHealthSet.Invoke(currentHitPoints);
	}

	public void TakeDamage(float damageAmount)
	{
		if ((invulnerability) || currentHitPoints <= 0)
			return;

		currentHitPoints -= damageAmount;

		bool dead = false;
		dead = currentHitPoints <= 0;

		if (dead)
		{
			currentHitPoints = 0;
			onDied.Invoke();
		}
		else
		{
			onTakeDamage.Invoke();
		}

		onHealthSet.Invoke(currentHitPoints);
	}

	public bool Invulnerable(float duration)
	{
		if (invulnerability)
			return false;

		invulenrabilityTime = duration;
		invulnerability = true;

		return true;
	}

	public bool GainHealth(float amount)
	{
		if (currentHitPoints > maxHitPoints)
		{
			return false;
		}

		currentHitPoints += amount;

		onHealthSet.Invoke(currentHitPoints);
		onGainHealth.Invoke();
		return true;
	}

}