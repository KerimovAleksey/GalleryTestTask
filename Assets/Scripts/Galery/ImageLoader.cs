using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{
	[SerializeField] private string _imagePath;

	[SerializeField] private RectTransform _content;
	[SerializeField] private GameObject _imageTemplate;

	public void LoadImage(int number, GameObject imagePrefab)
	{
		StartCoroutine(DownloadImage(_imagePath + number.ToString() + ".jpg", imagePrefab));
	}

	private IEnumerator DownloadImage(string url, GameObject imagePrefab)
	{
		UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
		yield return request.SendWebRequest();
		if (request.result == UnityWebRequest.Result.ProtocolError)
			Debug.Log(request.error);
		else
			imagePrefab.GetComponent<RawImage>().texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
	}
}
