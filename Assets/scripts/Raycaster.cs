using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private UserInput _userInput;
    [SerializeField] private Camera _camera;

    public event Action<BombCube> HittedCube;

    private RaycastHit _hit;
    private Ray _ray;

    private void OnEnable()
    {
        _userInput.ClickingButton += LaunchRay;
    }

    private void OnDisable()
    {
        _userInput.ClickingButton -= LaunchRay;
    }

    public void LaunchRay(Vector3 mousePosition)
    {
        _ray = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.gameObject.TryGetComponent(out BombCube bombCube))
            {
                HittedCube?.Invoke(bombCube);
            }
        }
    }
}
