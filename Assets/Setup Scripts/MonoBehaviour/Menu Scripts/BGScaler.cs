
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BGScaler : MonoBehaviour
{
	[SerializeField] SpriteRenderer sr;
	private void Reset()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	private void Start()
	{

		Vector3 tempScale = transform.localScale;

		float width = sr.sprite.bounds.size.x;

		float worldHeight = Camera.main.orthographicSize * 2f;
		float worldWidth = worldHeight / Screen.height * Screen.width;

		tempScale.x = worldWidth / width;

		transform.localScale = tempScale;
	}
}