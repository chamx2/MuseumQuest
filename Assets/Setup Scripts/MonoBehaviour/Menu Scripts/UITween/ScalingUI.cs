using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(RectTransform))]
public class ScalingUI : MonoBehaviour
{
	[SerializeField] bool animateOnStart = false;
	[Space()]
	[SerializeField] RectTransform panel;
	[SerializeField] Vector2 scaleInEndValue, scaleOutEndValue;
	[SerializeField] float scaleInDuration, scaleOutDuration;
	[Space(), SerializeField] UnityEvent OnScaleInComplete, OnScaleOutComplete;

#region Unity Methods	
	private void Reset()
	{
		panel = GetComponent<RectTransform>();
	}

	private void OnEnable()
	{
		if (animateOnStart)
		{
			HandleScaleOut();
		}
	}
#endregion

	public void HandleScaleIn()
	{
		Sequence startScale = DOTween.Sequence().OnComplete(() => ScaleInComplete()).SetUpdate(true);
		startScale.Append(panel.DOScale(scaleInEndValue, scaleInDuration));
	}
	public void HandleScaleOut()
	{
		Sequence startScale = DOTween.Sequence().OnComplete(() => ScaleOutComplete()).SetUpdate(true);
		startScale.Append(panel.DOScale(scaleOutEndValue, scaleOutDuration));
	}

	private void ScaleInComplete()
	{
		if (OnScaleInComplete != null)
		{
			OnScaleInComplete.Invoke();
		}
	}
	private void ScaleOutComplete()
	{
		if (OnScaleInComplete != null)
		{
			OnScaleOutComplete.Invoke();
		}
	}
}