using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ActionController : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private CounterViewer _counterViewer;
    [SerializeField] private UserInput _userInput;

    private void OnEnable()
    {
        _counter.OnAdd += _counterViewer.WriteNumber;
        _userInput.OnClickLeftMouse += _counter.SetCountingStage;
    }

    private void OnDisable()
    {
        _counter.OnAdd -= _counterViewer.WriteNumber;
       _userInput.OnClickLeftMouse -= _counter.SetCountingStage;
    }
}
