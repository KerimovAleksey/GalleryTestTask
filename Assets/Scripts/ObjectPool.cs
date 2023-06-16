using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _objCountForSpawn;
	[SerializeField] private GameObject _contentContainer;

    private List<GameObject> _pool = new List<GameObject>();

	private void Start()
	{
		for (int i = 0; i < _objCountForSpawn; i++)
		{
			InstantiateObj();
		}
	}

	private GameObject InstantiateObj()
	{
		var obj = Instantiate(_prefab, _contentContainer.transform);
		obj.SetActive(false);
		_pool.Add(obj);
		return obj;
	}

	public GameObject GetObject()
	{
		for (int i = 0; i < _pool.Count; i++)
		{
			if (_pool[i].activeSelf == false)
			{
				return _pool[i];
			}
		}
		return InstantiateObj();
	}
}
