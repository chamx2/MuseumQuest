using UnityEngine;

public class ActorAudio : MonoBehaviour
{
	[SerializeField] AudioSource audioSource;
	[SerializeField] SimpleAudioEvent simpleAudioEvent;


	public void HandlePlayAudio()
	{
		simpleAudioEvent.Play(audioSource);
	}
}