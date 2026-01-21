using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private const int ButtonIndex = 0;

    public event Action<Vector3> ClickingButton;

    private void Update()
    {
        ReadInput();
    }

    public void ReadInput()
    {
        if (Input.GetMouseButtonDown(ButtonIndex))
        {
            ClickingButton?.Invoke(Input.mousePosition);
        }
    }
}
