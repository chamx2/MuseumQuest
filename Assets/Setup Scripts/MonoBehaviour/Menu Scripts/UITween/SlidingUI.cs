using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(RectTransform))]
public class SlidingUI : MonoBehaviour
{
	[SerializeField] bool animateOnStart = false;
	[SerializeField] RectTransform panel;
	[SerializeField] Vector2 targetPos;
	[SerializeField] float duration;
	[SerializeField] Ease easeType;
	[Space(15), SerializeField] UnityEvent OnSlideInComplete, OnSlideOutComplete;
	Vector2 originalPos;

#region Unity Methods
	private void Reset()
	{
		panel = GetComponent<RectTransform>();
	}

	private void OnEnable()
	{
		originalPos = panel.localPosition;

		if (animateOnStart)
		{
			HandleSlideIn();
		}
	}
#endregion

	public void HandleSlideIn()
	{
		Sequence startSliding = DOTween.Sequence()
			.OnComplete(() => SlideInComplete()).SetUpdate(true);
		startSliding.Append(panel.DOAnchorPos(targetPos, duration).SetEase(easeType));
	}

	public void HandleSlideOut()
	{
		Sequence startSliding = DOTween.Sequence()
			.OnComplete(() => SlideOutComplete()).SetUpdate(true);
	startSliding.Append(panel.DOAnchorPos(originalPos, duration));
}

void SlideInComplete()
{
	if (OnSlideInComplete != null)
	{
		OnSlideInComplete.Invoke();
	}
}

void SlideOutComplete()
{
	if (OnSlideOutComplete != null)
	{
		OnSlideOutComplete.Invoke();
	}
}
}