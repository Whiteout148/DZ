using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _objectToShoot;
    private Coroutine _shootingCoroutine;

    [SerializeField] private float _timeToShoot = 3f;
    [SerializeField] private float _bulletSpeed = 10f;

    private bool _isShooting = true;

    void Start()
    {
        _shootingCoroutine = StartCoroutine(Shoot());
    }

    private void OnApplicationQuit()
    {
        _isShooting = false;
        StopCoroutine(_shootingCoroutine);
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds delay = new WaitForSeconds(_timeToShoot);

        while (_isShooting)
        {
            GameObject bullet = Instantiate(_prefab, transform.position, Quaternion.identity);
            bullet.transform.Translate(Vector3.forward * _bulletSpeed * Time.deltaTime);

            yield return delay;
        }
    }
}