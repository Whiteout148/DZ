using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actioner : MonoBehaviour
{
    [SerializeField] private Zhulik _zhulik;
    [SerializeField] private Signal _signal;

    private void OnEnable()
    {
        _zhulik.CameInHome += _signal.PlayClip;
        _zhulik.ExitHome += _signal.OffClip;
    }

    private void OnDisable()
    {
        _zhulik.CameInHome -= _signal.PlayClip;
        _zhulik.ExitHome -= _signal.OffClip;
    }
}
