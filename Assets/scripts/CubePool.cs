using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    private const float MinSpawnPosition = -10;
    private const float MaxSpawnPosition = 10;

    [SerializeField] private float _spawnHeight;
    [SerializeField] private Cube _cubePrefab;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            CreateFunc,
            OnGet,
            OnRelease
        );
    }

    public Cube GetCube()
    {
        return _pool.Get();
    }

    private void OnRelease(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody cubeRigidbody))
        {
            cubeRigidbody.isKinematic = true;
        }

        cube.ReturnedToPool -= OnReturningToPool;
        cube.gameObject.SetActive(false);
    }

    private void OnReturningToPool(Cube cube)
    {
        _pool.Release(cube);
    }

    private void OnGet(Cube cube)
    {
        cube.gameObject.SetActive(true);
        cube.transform.position = GetRandomEnableingPosition();

        if (cube.TryGetComponent(out Rigidbody cubeRigidbody))
        {
            cubeRigidbody.isKinematic = false;
        }

        cube.ReturnedToPool += OnReturningToPool;
    }

    private Cube CreateFunc()
    {
        return Instantiate(_cubePrefab, GetRandomEnableingPosition(), Quaternion.identity, transform.parent);
    }

    private Vector3 GetRandomEnableingPosition()
    {
        float positionX = UnityEngine.Random.Range(MinSpawnPosition, MaxSpawnPosition);
        float positionZ = UnityEngine.Random.Range(MinSpawnPosition, MaxSpawnPosition);

        return new Vector3(positionX, _spawnHeight, positionZ);
    }
}
