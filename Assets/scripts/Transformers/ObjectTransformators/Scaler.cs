using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scaler : ObjectTransformator
{
    public override void TransformObject()
    {
        transform.DOScale(EndValue, Duration).SetLoops(Loops, LoopType);
    }
}
