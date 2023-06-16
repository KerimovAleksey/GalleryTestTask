using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageTemplate : MonoBehaviour, IPointerClickHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if (!SceneManager.GetSceneByName("Viewer").IsValid())
		{
			ScenesBridge.SendImage(GetComponent<RawImage>().texture);
			SceneManager.LoadScene(3, LoadSceneMode.Additive);
		}
	}
}
