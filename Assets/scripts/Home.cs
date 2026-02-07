using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Signal _signal;
    [SerializeField] private HomeTrigger _trigger;

    private void OnEnable()
    {
        _trigger.RobberCameInside += OnRobberIn;
        _trigger.RobberCameOut  += OnRobberOut;
    }

    private void OnDisable()
    {
        _trigger.RobberCameInside -= OnRobberIn;
        _trigger.RobberCameOut -= OnRobberOut;
    }

    private void OnRobberIn()
    {
        _signal.PlayClip();
    }

    private void OnRobberOut()
    {
        _signal.OffClip();
    }
}
