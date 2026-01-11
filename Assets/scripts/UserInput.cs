using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    [SerializeField] private Counter _counter;

    private void Update()
    {
        StartWithUser();
    }

    private void StartWithUser()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_counter.IsRunning)
            {
                _counter.StopAddNumber();
            }
            else
            {
                _counter.StartAddNumber();
            }
        }
    }
}
