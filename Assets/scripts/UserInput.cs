using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const int LeftMouseButton = 0;

    public Action OnClickLeftMouse;
    private bool _isRunning = false;

    private void Update()
    {
        StartWithUser();
    }

    private void StartWithUser()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            OnClickLeftMouse?.Invoke();
        }
    }
}
