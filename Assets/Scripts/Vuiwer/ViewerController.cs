using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ViewerController : MonoBehaviour
{
	[SerializeField] private RawImage _imageContainer;
	private void Start()
	{
		Screen.orientation = ScreenOrientation.AutoRotation;
		_imageContainer.texture = ScenesBridge.GetImage();
	}

	private void Update()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKeyUp(KeyCode.Escape))
			{
				CloseScene();
			}
		}
	}

	public void CloseScene()
	{
		Screen.orientation = ScreenOrientation.Portrait;
		SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Viewer"));
	}
}
