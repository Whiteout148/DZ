using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectTransformator : Transformator
{
    [SerializeField] protected Vector3 EndValue;

    public override void ReTransform()
    {
        TransformObject();
    }

    public abstract void TransformObject();
}
