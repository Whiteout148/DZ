using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCube : MonoBehaviour
{
    private const int MinClonesCount = 2;
    private const int MaxClonesCount = 6;
    private const int MaxChance = 100;
    private const int ForceFactor = 4; 
    private const int RadiusFactor = 2;

    private int _chanceDivider = 2;
    private int _chanceToDivide = 100;

    public float ExplosionRadius { get; private set; } = 40;
    public float ExplosionForce { get; private set; } = 100;

    public bool IsDivideable()
    {
        return UnityEngine.Random.Range(0, MaxChance) <= _chanceToDivide;
    }

    public void ChangeProperties()
    {
        _chanceToDivide /= _chanceDivider;
        ExplosionRadius *= RadiusFactor;
        ExplosionForce *= ForceFactor;
    }
}
