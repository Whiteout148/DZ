using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCube : MonoBehaviour
{
    private const int MinClonesCount = 2;
    private const int MaxClonesCount = 6;
    private const int MaxChance = 100;

    private int _chanceDivider = 2;
    private int _chanceToDivide = 100;

    public bool IsDivideable()
    {
        return UnityEngine.Random.Range(0, MaxChance) <= _chanceToDivide;
    }

    public void DivideChance()
    {
        _chanceToDivide /= _chanceDivider;
    }
}
