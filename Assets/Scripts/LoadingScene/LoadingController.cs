using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingController : MonoBehaviour
{
	[SerializeField] private Image _progressBar;
	[SerializeField] private TMP_Text _loadingLabel;
	[SerializeField] private float _loadingTimeInSeconds;

	// Для обычной загрузки сцены, без лишних 2-3 секунд
	/*     
	AsyncOperation loadingOperation;

	
	private void Start()
	{
		loadingOperation = SceneManager.LoadSceneAsync(PlayerPrefs.GetInt("SceneToLoad"));
	}

	private void FixedUpdate()
	{
		float progressValue = Mathf.Clamp01(loadingOperation.progress / 0.9f);

		_progressBar.fillAmount = progressValue;
		_loadingLabel.text = Mathf.Round(progressValue * 100) + "%";
	}
	*/

	// Загрузка сцены по ТЗ, с 2-3с задержкой
	private void Start()
	{
		StartCoroutine(nameof(LoadScene));
	}

	private IEnumerator LoadScene()
	{
		float value = 0;
		float delta = Time.deltaTime / _loadingTimeInSeconds;
		while (value != 1)
		{
			value += delta;

			if (value > 1)
				value = 1;

			_progressBar.fillAmount = value;
			_loadingLabel.text = ((int)(value * 100f)).ToString() + "%";

			yield return new WaitForSeconds(delta);
		}
		SceneManager.LoadScene(PlayerPrefs.GetInt("SceneToLoad"));
	}

}
