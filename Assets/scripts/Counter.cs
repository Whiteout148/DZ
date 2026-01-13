using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public Action OnAdd;

    [SerializeField] private float _delayTime = 0.5f;

    private int _changedNumber = 0;
    private bool _isRunning = false;
    private Coroutine _coroutineCounter;

    public void StartCounting()
    {
        _isRunning = true;
        _coroutineCounter = StartCoroutine(AddNumber());
    }

    public void StopCounting()
    {
        if (_coroutineCounter != null)
        {
            _isRunning = false;
            StopCoroutine(_coroutineCounter);
        }    
    }

    private IEnumerator AddNumber()
    {
        WaitForSeconds delay = new WaitForSeconds(_delayTime);

        while (_isRunning)
        {
            _changedNumber++;
            OnAdd?.Invoke();

            yield return delay;
        }
    }
}
