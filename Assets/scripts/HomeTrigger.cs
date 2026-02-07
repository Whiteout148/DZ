using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeTrigger : MonoBehaviour
{
    public event Action RobberCameInside;
    public event Action RobberCameOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Robber>(out _))
        {
            RobberCameInside?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<Robber>(out _))
        {
            RobberCameOut?.Invoke();
        }
    }
}
