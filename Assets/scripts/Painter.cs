using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    private UnityEngine.Color _defaultColor;

    private void Awake()
    {
        _defaultColor = Color.white;
    }

    public void SetDefaultColor(Cube cube)
    {
        if (cube.TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = _defaultColor;
        }
    }

    public void OnCollisedFloor(Cube cube)
    {
        if (cube.TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = UnityEngine.Random.ColorHSV();
        }
    }
}
