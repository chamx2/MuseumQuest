using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Damager : Element
{
	[SerializeField] FloatReference damage;
	[Space()]
	[SerializeField] UnityEvent OnDamageableHit, OnNonDamageableHit;
	new Collider collider;

	private void Reset()
	{
		collider = GetComponent<Collider>();
		collider.isTrigger = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		Damageable damageable = other.transform.GetComponent<Damageable>();

		if (damageable != null)
		{
			damageable.TakeDamage(damage);
			OnDamageableHit.Invoke();
		}
		else
		{
			OnNonDamageableHit.Invoke();
		}
	}
}