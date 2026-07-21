using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextTransformator : Transformator
{
    [SerializeField] private string _toChange;
    [SerializeField] private Text _text;
    [SerializeField] private float _delay;

    public override void ReTransform()
    {
        _text.DOText(_toChange, Duration).SetDelay(_delay).SetLoops(Loops, LoopType);
    }
}
