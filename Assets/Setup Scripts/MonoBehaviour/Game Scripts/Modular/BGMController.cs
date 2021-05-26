using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

public class BGMController : MonoBehaviour
{
	[SerializeField] float duration;
	[SerializeField] AudioMixer bgmMixer;
	[Space()]
	[SerializeField] AudioSource mainMenuBGMAudioSource;
	[SerializeField] AudioSource gameSceneAudioSource;
	[SerializeField] AudioSource scoreMenuBGMAudioSource;

	public void HandleMainMenuBGM()
	{
		mainMenuBGMAudioSource.Play();
		bgmMixer.DOSetFloat("MainMenu", 0, duration);
		bgmMixer.DOSetFloat("GameScene", -80, duration).OnComplete(() => gameSceneAudioSource.Stop());
		bgmMixer.DOSetFloat("ScoreScene", -80, duration).OnComplete(() => scoreMenuBGMAudioSource.Stop());
	}

	public void HandleGameBGM()
	{
		gameSceneAudioSource.Play();
		bgmMixer.DOSetFloat("GameScene", 0, duration);
		bgmMixer.DOSetFloat("MainMenu", -80, duration).OnComplete(() => mainMenuBGMAudioSource.Stop());
	}

	public void HandleScoreSceneBGM()
	{
		scoreMenuBGMAudioSource.Play();
		bgmMixer.DOSetFloat("ScoreScene", 0, duration);
		bgmMixer.DOSetFloat("GameScene", -80, duration).OnComplete(() => gameSceneAudioSource.Stop());
	}

}