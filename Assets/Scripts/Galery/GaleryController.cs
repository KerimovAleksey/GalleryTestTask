using UnityEngine;
using UnityEngine.UI;

public class GaleryController : MonoBehaviour
{
	[SerializeField] private string _imagePathFolder;
	[SerializeField] private int _imageCount;
	[SerializeField] private GameObject _contentContainer;
	[SerializeField] private GameObject _scrollView;

	[SerializeField] private ImageLoader _imageLoader;
	[SerializeField] private ObjectPool _objPool;

	private RectTransform _contentRectTransform;

	private Vector2 _cellSize;
	private Vector2 _cellsSpacing;
	private Vector2 _scrollViewSize;

	private float _oneImageYSize;
	private int _displayedRows;
	private int _counterOfDisplayedImages = 1; // Стартовый номер картинки в хранилище

	private void Start()
	{
		var gridComp = _contentContainer.GetComponent<GridLayoutGroup>();

		_contentRectTransform = _contentContainer.GetComponent<RectTransform>();
		_scrollViewSize = _scrollView.GetComponent<RectTransform>().sizeDelta;

		_cellSize = gridComp.cellSize;
		_cellsSpacing = gridComp.spacing;

		_oneImageYSize = _cellSize.y + _cellsSpacing.y;

		// Устанавливаем размер поля контента в соответсствии с кол-вом картинок
		_contentRectTransform.sizeDelta = new Vector2(0, _oneImageYSize * _imageCount / 2);

		// Стартовое заполнение
		// +1 для невилирования дробного значения, которое не учитывается
		AddNewImages((int)(_scrollViewSize.y / _oneImageYSize) + 1);
	}

	private void AddNewImages(int rowsCount)
	{
		for (int i = 0; i < rowsCount * 2; i++)
		{
			var obj = _objPool.GetObject();
			obj.SetActive(true);
			_imageLoader.LoadImage(_counterOfDisplayedImages, obj);
			_counterOfDisplayedImages++;
		}
		_displayedRows += rowsCount;
	}

	public void ContentScrolling()
	{
		// левая часть условия - получаем координаты нижней части экрана
		// права часть - получаем координаты тригера, когда нужно создать новые картинки
		if (_contentRectTransform.anchoredPosition.y + _scrollViewSize.y > (_displayedRows * _oneImageYSize))
		{
			AddNewImages(1);
		}
	}

}
