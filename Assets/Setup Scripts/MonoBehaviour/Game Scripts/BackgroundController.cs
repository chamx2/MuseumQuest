using UnityEngine;

public class BackgroundController : MonoBehaviour
{
	[System.Serializable]
	class BackgroundDataList
	{
		public Sprite backgroundSprite;
		public int colorIndex;
	}

	[SerializeField] SpriteRenderer backgroundSpriteRender;
	[SerializeField] BackgroundDataList[] backgroundDataList;
	[SerializeField] GameEvent onUpdateBarGaugeColor;



	public void HandleUpdateBackground()
	{
		var randomResult = Random.Range(0, backgroundDataList.Length);

		backgroundSpriteRender.sprite = backgroundDataList[randomResult].backgroundSprite;

		onUpdateBarGaugeColor.sentInt = backgroundDataList[randomResult].colorIndex;
		onUpdateBarGaugeColor.Raise();
	}
}