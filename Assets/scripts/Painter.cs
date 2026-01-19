using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    private List<UnityEngine.Color> _colors = new List<UnityEngine.Color>();

    public UnityEngine.Color GetRandomColor()
    {
        return _colors[UserUtils.GetRandomNumber(0, _colors.Count - 1)];
    }

    private void Start()
    {
        AddColors();
    }

    private void AddColors()
    {
        _colors.Add(Color.white);
        _colors.Add(Color.red);
        _colors.Add(Color.blue);
        _colors.Add(Color.green);
    }
}
