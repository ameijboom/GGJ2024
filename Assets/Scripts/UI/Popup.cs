using MyBox;
using Player;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace UI
{
	public class Popup : MonoBehaviour
	{
		private enum PopupStateEnum
		{
			Hidden,
			CountingDown,
			Thanks,
		}

		[SerializeField, MustBeAssigned] private Dash playerDash;
		[SerializeField] private int countDownSeconds;
		[SerializeField] private string thanksText;
		[FormerlySerializedAs("randomChangePerSecond")] [SerializeField, Range(0f, 100f)] private float randomChancePerSecond;

		[SerializeField, ReadOnly] private PopupStateEnum popupState;

		private Canvas _canvas;
		private TMP_Text _popupText;
		private string _initialPopupText;

		private PopupStateEnum PopupState
		{
			get { return popupState; }
			set
			{
				switch(value)
				{
					case PopupStateEnum.Hidden:
						_canvas.enabled = false;
						break;
					case PopupStateEnum.CountingDown:
						_canvas.enabled = true;
						_popupText.text = string.Format(_initialPopupText, countDownSeconds);
						break;
					case PopupStateEnum.Thanks:
						playerDash.DoDash();
						_canvas.enabled = true;
						_popupText.text = thanksText;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(value), value, null);
				}
				popupState = value;
			}
		}

		private void Awake()
		{
			_canvas = GetComponentInParent<Canvas>();

			_popupText = GetComponentInChildren<TMP_Text>();
			_initialPopupText = _popupText.text;

			PopupState = PopupStateEnum.Hidden;
		}

		private void Start()
		{
			InvokeRepeating(nameof(TryShowPopup), 5f, 1f); //start after 5 seconds, repeat every second
		}

		private void TryShowPopup()
		{
			if (PopupState == PopupStateEnum.Hidden)
			{
				if (Random.Range(0f, 100f) < randomChancePerSecond)
					StartCoroutine(Countdown());
			}
		}

		private IEnumerator Countdown()
		{
			PopupState = PopupStateEnum.CountingDown;
			for(int i = countDownSeconds - 1; i > 0; i--)
			{
				yield return new WaitForSeconds(1f);
				_popupText.text = string.Format(_initialPopupText, i);
			}

			yield return new WaitForSeconds(0.5f);

			yield return Thank();
		}

		private IEnumerator Thank()
		{
			PopupState = PopupStateEnum.Thanks;

			yield return new WaitForSeconds(2f);

			PopupState = PopupStateEnum.Hidden;
		}

		private void Update()
		{
			if (PopupState == PopupStateEnum.CountingDown)
			{
				if (Input.GetKeyDown(KeyCode.W))
				{
					StopAllCoroutines();
					StartCoroutine(Thank());
				}
			}
		}
	}
}
