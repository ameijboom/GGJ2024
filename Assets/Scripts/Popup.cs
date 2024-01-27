using System.Collections;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
	[SerializeField] private Canvas _canvas;
	[SerializeField] private Dash _playerDash;
	[SerializeField] private float _timeBetweenPopups;

	private Coroutine _dashRoutine;
	private Rect _rect;
	private string _initialPopupText;
	private TMP_Text _popupText;

	private void Awake()
	{
		_rect = GetComponent<RectTransform>().rect;

		_popupText = GetComponentInChildren<TMP_Text>();
		_initialPopupText = _popupText.text;
	}

	private void Start()
	{
		_canvas.enabled = false;
		StartCoroutine(LoopMaybeShowPopup());
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) && _canvas.enabled)
		{
			StopCoroutine(_dashRoutine);
			StartCoroutine(AfterPurchase());
		}
	}

	private Vector2 GetRandomPositionOnCanvas() => new(
		Random.Range(0 + _rect.width, _canvas.pixelRect.width - _rect.width),
		Random.Range(0 + _rect.height, _canvas.pixelRect.height - _rect.height));

	private IEnumerator LoopMaybeShowPopup()
	{
		for(;;)
		{
			int random = Random.Range(1, 15);

			if (!_canvas.enabled)
			{
				if (random <= 5)
				{
					_canvas.enabled = true;
					_dashRoutine = StartCoroutine(ForceDash());
				}

				transform.position = GetRandomPositionOnCanvas();

				yield return new WaitForSeconds(_timeBetweenPopups);
			}

			yield return null;
		}
	}

	private IEnumerator ForceDash()
	{
		const int maxTime = 5;
		_popupText.text = string.Format(_initialPopupText, maxTime);
		for (int i = maxTime - 1; i >= 0; i--)
		{
			yield return new WaitForSeconds(1f);
			_popupText.text = string.Format(_initialPopupText, i);
		}
		_playerDash.DoDash();
		StartCoroutine(AfterPurchase());
	}

	private IEnumerator AfterPurchase()
	{
		_popupText.text = "Thank you for your purchase!";
		yield return new WaitForSeconds(2f);
		_canvas.enabled = false;
	}
}
