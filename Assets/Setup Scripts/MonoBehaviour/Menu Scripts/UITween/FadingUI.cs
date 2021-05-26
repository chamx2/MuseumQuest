using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CanvasGroup))]
public class FadingUI : MonoBehaviour
{
	[SerializeField] bool animateOnStart = false;
	[SerializeField] bool setCanvasGroupInteractable = false;
	[SerializeField] CanvasGroup canvasGroup;
	[SerializeField] float fadeInDuration, fadeOutDuration;
	[Space(), SerializeField] UnityEvent OnFadeInComplete, OnFadeOutComplete;

#region Unity Methods
	private void Reset()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	private void OnEnable()
	{
		if (animateOnStart)
		{
			HandleFadeIn();
		}
	}
#endregion

	public void HandleFadeIn()
	{
		Sequence startFade = DOTween.Sequence().OnComplete(() => FadeInComplete()).SetUpdate(true);
		startFade.Append(canvasGroup.DOFade(1, fadeInDuration));

		if (setCanvasGroupInteractable)
		{
			canvasGroup.interactable = true;
			canvasGroup.blocksRaycasts = true;
		}
	}

	public void HandleFadeOut()
	{
		Sequence startFade = DOTween.Sequence().OnComplete(() => FadeOutComplete()).SetUpdate(true);
		startFade.Append(canvasGroup.DOFade(0, fadeOutDuration));

		if (setCanvasGroupInteractable)
		{
			canvasGroup.interactable = false;
			canvasGroup.blocksRaycasts = false;
		}
	}

	private void FadeInComplete()
	{
		if (OnFadeInComplete != null)
		{
			OnFadeInComplete.Invoke();
		}
	}

	private void FadeOutComplete()
	{
		if (OnFadeOutComplete != null)
		{
			OnFadeOutComplete.Invoke();
		}
	}

}