using System.Collections;
using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Counter _counter;

    private void Update()
    {
        SetText();
    }

    private void SetText()
    {
        _counterText.text = _counter.Check.ToString();
    }
}
