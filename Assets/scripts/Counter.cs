using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private Coroutine _checkCoroutine;

    public int Check { get; private set; } = 0;
    public float TimeToUpdate { get; private set; } = 0.5f;
    public bool IsRunning { get; private set; } = false;

    public void StartAddNumber()
    {
        if (IsRunning == false)
        {
            IsRunning = true;
            _checkCoroutine = StartCoroutine(AddNumber());
        }
    }

    public void StopAddNumber()
    {
        if (IsRunning)
        {
            IsRunning = false;
            _checkCoroutine = null;
        }
    }

    private IEnumerator AddNumber()
    {
        WaitForSeconds delay = new WaitForSeconds(TimeToUpdate);

        while (IsRunning)
        {
            Check++;

            yield return delay;
        }
    }
}
