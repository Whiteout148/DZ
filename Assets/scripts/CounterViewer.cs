using System.Collections;
using TMPro;
using UnityEngine;

public class CounterViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _counterNumber;
    private int _number = 0;

    public void WriteNumber()
    {
        _number++;
        _counterNumber.text = _number.ToString();
    }
}
