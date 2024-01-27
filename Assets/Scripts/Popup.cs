using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _timeBetweenPopups;
    private Dash _dash;
    private Coroutine _dashRoutine;
    private Rect _rect;
    // Start is called before the first frame update
    void Start()
    {
        _rect = GetComponent<RectTransform>().rect;
        _canvas.enabled = false;

        _dash = _player.GetComponent<Dash>();

        StartCoroutine(ShowPopup());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _canvas.enabled)
        {
            StopCoroutine(_dashRoutine);
            _canvas.enabled = false;
        }
    }

    private Vector2 GetRandomPositionOnCanvas() => new Vector2(
        Random.Range(0 + _rect.width, _canvas.pixelRect.width - _rect.width),
        Random.Range(0 + _rect.height, _canvas.pixelRect.height - _rect.height));

    IEnumerator ShowPopup()
    {
        for(;;)
        {
            int random = Random.Range(1, 11);

            if (random <= 5) 
            {
                _canvas.enabled = true;
                _dashRoutine = StartCoroutine(ForceDash());

            } else
            {
                _canvas.enabled = false;
            }

            transform.position = GetRandomPositionOnCanvas();

            yield return new WaitForSeconds(_timeBetweenPopups);
        }
    }

    IEnumerator ForceDash()
    {
        yield return new WaitForSeconds(5f);
        _dash.DoDash();
        _canvas.enabled = false;
    }
}
