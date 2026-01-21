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

    public bool TryToDivide()
    {
        if (UnityEngine.Random.Range(0, MaxChance) <= _chanceToDivide)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void DivideChance()
    {
        _chanceToDivide /= _chanceDivider;
    }

    public int GetRandomClonesCount()
    {
        return UnityEngine.Random.Range(MinClonesCount, MaxClonesCount);
    }
}
