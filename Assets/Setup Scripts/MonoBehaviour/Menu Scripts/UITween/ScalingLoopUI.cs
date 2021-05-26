using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class ScalingLoopUI : MonoBehaviour
{
	[SerializeField] LoopType loopType = LoopType.Yoyo;
	[SerializeField] float duration = 1f;
	[SerializeField] float targetScale = 1.2f;
	[SerializeField] RectTransform panel;

	void Reset()
	{
		panel = GetComponent<RectTransform>();
	}

	void Start()
	{
		panel.DOScale(targetScale, duration)
			.SetLoops(-1, loopType)
			.Play();
	}
}