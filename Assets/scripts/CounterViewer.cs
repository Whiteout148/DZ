using System.Collections;
using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterText;
    [SerializeField] private Counter _counter;
    private bool _isRunning = false;

    private void Update()
    {
        ManageCheck();
    }

    private void ManageCheck()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isRunning)
            {
                _isRunning = false;
                StopCoroutine(CounterCoroutine());
            }
            else
            {
                _isRunning = true;
                StartCoroutine(CounterCoroutine());
            }
        }
    }

    private IEnumerator CounterCoroutine()
    {
        while (_isRunning)
        {
            _counter.CheckUpdate();
            _counterText.text = _counter.Check.ToString();

            yield return new WaitForSeconds(_counter.TimeToUpdate);
        }
    }
}
