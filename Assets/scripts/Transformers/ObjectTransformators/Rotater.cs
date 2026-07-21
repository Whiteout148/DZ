using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotater : ObjectTransformator
{
    public override void TransformObject()
    {
        transform.DORotate(EndValue, Duration).SetLoops(Loops, LoopType); 
    }
}
