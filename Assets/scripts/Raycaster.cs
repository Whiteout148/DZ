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

    public Action OnHitCube;

    private RaycastHit _hit;
    private Ray _ray;

    private void OnEnable()
    {
        _userInput.OnClickLeftMouse += LaunchRay;
    }

    private void OnDisable()
    {
        _userInput.OnClickLeftMouse -= LaunchRay;
    }

    public void LaunchRay()
    {
        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.transform.gameObject.GetComponent<Exploder>())
            {
                OnHitCube?.Invoke();
            }
        }
    }

    public GameObject GetHittedObject()
    {
        return _hit.transform.gameObject;
    }
}
