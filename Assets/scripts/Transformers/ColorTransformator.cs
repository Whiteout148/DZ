using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransformator : Transformator
{
    [SerializeField] private Material _material;
    [SerializeField] private MeshRenderer _meshRenderer;

    public override void ReTransform()
    {
        _meshRenderer.material.DOColor(_material.color, Duration).SetLoops(Loops, LoopType);
    }
}
