using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Signal : MonoBehaviour
{
    private const float MaxVolume = 1f;
    private const float MinVolume = 0f;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _step = 1f;

    private Coroutine _volumeCoroutine;

    private void Awake()
    {
        _audioSource.volume = 0f;
    }

    public void PlayClip()
    {
        if (_volumeCoroutine != null)
        {
            StopCoroutine(_volumeCoroutine);
        }

        _audioSource.Play();
        _volumeCoroutine = StartCoroutine(ChangeVolume(MaxVolume, false));
    }

    public void OffClip()
    {
        if (_volumeCoroutine != null)
        {
            StopCoroutine(_volumeCoroutine);
        }

        _volumeCoroutine = StartCoroutine(ChangeVolume(MinVolume, true));
    }

    private IEnumerator ChangeVolume(float endVolume, bool stopOnFinish)
    {
        while (!Mathf.Approximately(_audioSource.volume, endVolume))
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, endVolume, _step * Time.deltaTime);
                
            yield return null;
        }

        if (stopOnFinish)
        {
            _audioSource.Stop();
        }
    }
}