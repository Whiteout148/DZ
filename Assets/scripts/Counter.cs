using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public int Check { get; private set; } = 0;
    public float TimeToUpdate { get; private set; } = 0.5f;

    public void CheckUpdate()
    {
        Check++;
    }
}
