using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float _enlargeingCount;

    private void Update()
    {
        Enlarge();
    }

    private void Enlarge()
    {
        transform.localScale += Vector3.one * _enlargeingCount * Time.deltaTime; ;
    }
}
