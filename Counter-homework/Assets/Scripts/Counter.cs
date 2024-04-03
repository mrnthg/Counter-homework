using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _smoothIncreaseDuration = 0.5f;
    [SerializeField] private float _stepIncrease = 1f;
    [SerializeField] private TextMeshProUGUI _textCounter;

    private float _minValue = 0f;
    private bool _isClick = false;

    private void Start()
    {
        _textCounter.text = _minValue.ToString("");
    }

    private void Update()
    {
        if (_isClick)
            StartCoroutine(IncreaseDurationCount());
    }

    public void MouseClick()
    {
        if (_isClick)
        {          
            _isClick = false;
        }
        else
        {
            _isClick = true;
        }
    }

    private IEnumerator IncreaseDurationCount()
    {
        float elapsedTime = 0f;
        float previousValue = float.Parse(_textCounter.text);

        while (elapsedTime < _smoothIncreaseDuration && _isClick)
        {
            elapsedTime += Time.deltaTime;       
            float intermediateValue = previousValue + _stepIncrease;
            _textCounter.text = intermediateValue.ToString("");

            yield return null;
        }
    }
}
