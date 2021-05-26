using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Class to change Scenes to Scenes, Called by Unity Event System
/// </summary>
public class LevelChanger : MonoBehaviour
{
	[System.Serializable]
	public class LoadAsync
	{
		public bool loadAsynchronously = false;
		public GameObject loadingScreen;
		public Slider slider;
		public Text progressText;
	}

	[SerializeField] bool SetAnimator;
	[ SerializeField] Animator myAnim;
	[SerializeField] string parameterName;
	[SerializeField] LoadAsync loadAsync = new LoadAsync();
	int levelToLoad;
	int parameterIndex;

#region Unity Methods
	void OnValidate()
	{
		if (myAnim != null)
		{
			myAnim.enabled = SetAnimator ? true : false;
		}
	}

	void Start()
	{
		parameterIndex = Animator.StringToHash(parameterName);
	}
#endregion

	/// <summary>
	/// Called by Unity Event System in the Scene
	/// </summary>
	/// <param name="levelIndex">Next Scene to Load</param>
	public void LoadToLevel(int levelIndex)
	{
		if (!SetAnimator)
		{
			SceneManager.LoadScene(levelIndex);
		}
		else
		{
			levelToLoad = levelIndex;
			myAnim.SetTrigger(parameterIndex);
		}
	}

#region Private Methods
	/// <summary>
	/// Called by Animation Event
	/// </summary>
	void OnFadeComplete()
	{
		if (!loadAsync.loadAsynchronously)
		{
			SceneManager.LoadScene(levelToLoad);
		}
		else
		{
			StartCoroutine(LoadAsynchronously(levelToLoad));
		}

	}

	/// <summary>
	/// Load Asynchronously to next Scene
	/// </summary>
	/// <param name="sceneIndex">Next Scene to Load</param>
	/// <returns>returning null</returns>
	IEnumerator LoadAsynchronously(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex); // Ready to load to next Scene

		loadAsync.loadingScreen.SetActive(true); //Set loading screen GUI active

		while (!operation.isDone) // loop until operation async is not done
		{
			float progress = Mathf.Clamp01(operation.progress / 0.9f);

			loadAsync.slider.value = progress; // reflect the progress data into GUI Bar
			loadAsync.progressText.text = progress * 100f + "%"; // reflect the progress data into GUI Text

			yield return null; // wait until next frame rate
		}
	}
#endregion
}