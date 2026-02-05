using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zhulik : MonoBehaviour
{
    public event Action CameInHome;
    public event Action ExitHome;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<HomeTrigger>(out HomeTrigger homeTrigger))
        {
            CameInHome?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<HomeTrigger>(out HomeTrigger homeTrigger))
        {
            ExitHome?.Invoke();
        }
    }
}
