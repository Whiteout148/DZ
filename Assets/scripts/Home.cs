using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    [SerializeField] private Signal _signal;
    [SerializeField] private HomeTrigger _trigger;

    private void OnEnable()
    {
        _trigger.RobberCameInside += _signal.PlayClip;
        _trigger.RobberCameOut  += _signal.OffClip;
    }

    private void OnDisable()
    {
        _trigger.RobberCameInside -= _signal.PlayClip;
        _trigger.RobberCameOut -= _signal.OffClip;
    }
}
