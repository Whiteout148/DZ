using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    public event Action OnClickLeftMouse;

    private const int LeftMouseButton = 0;

    private void Update()
    {
        SetUserInput();
    }

    public void SetUserInput()
    {
        if (Input.GetMouseButtonDown(LeftMouseButton))
        {
            OnClickLeftMouse?.Invoke();
        }
    }
}
