using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BlinkCanvasGroup : MonoBehaviour
{
	[SerializeField] float durationSeconds = 1f;
	[SerializeField] Ease easeType;
	[SerializeField] LoopType loopType;
	[SerializeField] CanvasGroup canvasGroup;

	void Reset()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}

	void Start()
	{
		canvasGroup.DOFade(0.0f, durationSeconds)
			.SetEase(easeType)
			.SetLoops(-1, loopType);
	}
}