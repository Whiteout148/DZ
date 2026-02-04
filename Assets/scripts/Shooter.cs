using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private Transform _objectToShoot;
    [SerializeField] private float _timeToShoot = 3f;

    private Coroutine _shootingCoroutine;

    private bool _isShooting = true;

    private void Start()
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
            Vector3 direction = (_objectToShoot.position - transform.position).normalized;
            Bullet spawnedBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);

            if (spawnedBullet.TryGetComponent(out Rigidbody bulletRigidbody))
            {
                bulletRigidbody.transform.up = direction;
                bulletRigidbody.velocity = direction * spawnedBullet.Speed;
            }

            yield return delay;
        }
    }
}