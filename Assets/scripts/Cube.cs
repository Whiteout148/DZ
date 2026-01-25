using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private const int MinTimeToReturn = 2;
    private const int MaxTimeToReturn = 5;
    private const string FloorTag = "Floor";

    public event Action<Cube> ReturnedToPool;
    private Coroutine _coroutine;
    private bool _isCollising = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == FloorTag)
        {
            _coroutine = StartCoroutine(CountDownToReturn());

            if (_isCollising == false)
            {
                if (transform.gameObject.TryGetComponent(out Renderer renderer))
                {
                    renderer.material.color = UnityEngine.Random.ColorHSV();
                }

                _isCollising = true;
            }
        }
    }

    private IEnumerator CountDownToReturn()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(MinTimeToReturn, MaxTimeToReturn));

        ReturnedToPool?.Invoke(this);
        _isCollising = false;
    }
}
