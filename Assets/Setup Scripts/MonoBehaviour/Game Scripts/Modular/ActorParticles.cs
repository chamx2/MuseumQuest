using UnityEngine;

public class ActorParticles : MonoBehaviour
{
	[SerializeField] ParticleSystem comeParticleSystem;



	public void HandlePlayComeParticle()
	{
		comeParticleSystem.Play();
	}
}