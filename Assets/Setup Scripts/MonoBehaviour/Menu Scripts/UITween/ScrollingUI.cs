using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class ScrollingUI : MonoBehaviour
{
	[SerializeField] RectTransform panel;
	[SerializeField] Ease easeType;
	[SerializeField] Vector2 targetPos;
	[SerializeField] Vector2 finalPos;
	[SerializeField] float duration;
	[Space()]
	[SerializeField] UnityEvent onLoop;
	[SerializeField] UnityEvent onEndLoop;
	Vector2 originalPos;
	bool shouldLoop;
	Tween myTween;

	void Awake()
	{
		originalPos = panel.localPosition;
	}

	void StartSliding()
	{
		if (shouldLoop)
		{
			panel.localPosition = originalPos;
			myTween = panel.DOAnchorPos(targetPos, duration);
			myTween.OnComplete(() => StartSliding());

			if (onLoop != null)
			{
				onLoop.Invoke();
			}
		}
		else
		{
			panel.localPosition = originalPos;
			myTween = panel.DOAnchorPos(finalPos, duration).OnComplete(() => EndLoop()).SetEase(easeType);
		}
	}

	void EndLoop()
	{
		if (onEndLoop != null)
		{
			onEndLoop.Invoke();
		}
	}

	public void HandleLoop()
	{
		shouldLoop = true;
		StartSliding();
	}

	public void HandleStopLoop()
	{
		shouldLoop = false;
	}
}