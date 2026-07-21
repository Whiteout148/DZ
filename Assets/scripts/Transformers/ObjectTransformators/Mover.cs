using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Mover : ObjectTransformator
{
    public override void TransformObject()
    {
        transform.DOMove(EndValue, Duration).SetLoops(Loops, LoopType);
    }
}
