using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private const int MinTimeToRespawn = 2;
    private const int MaxTimeToRespawn = 5;

    private Coroutine _coroutine;

    public event Action<Cube> CollisedFloor;
    public event Action<Cube> Respawned;

    public bool IsCollising { get; private set; } = false;

    public void ResetVelocity()
    {
        if (transform.TryGetComponent(out Rigidbody cubeRigidbody))
        {
            cubeRigidbody.velocity = Vector3.zero;
            cubeRigidbody.angularVelocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Floor>(out Floor floor))
        {
            if (IsCollising == false)
            {
                CollisedFloor?.Invoke(this);
                IsCollising = true;
            }

            _coroutine = StartCoroutine(CountDownToDestroy());
        }
    }

    private IEnumerator CountDownToDestroy()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(MinTimeToRespawn, MaxTimeToRespawn));

        Respawned?.Invoke(this);
        IsCollising = false;
    }
}
