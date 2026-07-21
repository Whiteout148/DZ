using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public abstract class Transformator : MonoBehaviour
{
    [SerializeField] protected float Duration;
    [SerializeField] protected LoopType LoopType;
    [SerializeField] protected int Loops;

    private void Start()
    {
        ReTransform();
    }

    public abstract void ReTransform();
}
