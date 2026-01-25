using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CubePool : MonoBehaviour
{
    private const float MinSpawnPosition = -10;
    private const float MaxSpawnPosition = 10;
    private const float WaitTime = 0.5f;

    [SerializeField] private float _spawnHeight;
    [SerializeField] private Cube _cubePrefab;

    private UnityEngine.Color _defaultColor;
    private ObjectPool<Cube> _pool;
    private Coroutine _coroutine;
    private bool _isSpawning = false;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            CreateFunc,
            OnGet,
            OnRelease
        );

        _defaultColor = Color.white;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(SpawnCubes());
    }

    private void OnApplicationQuit()
    {
        _isSpawning = false;
        StopCoroutine(_coroutine);
    }

    private IEnumerator SpawnCubes()
    {
        WaitForSeconds delay = new WaitForSeconds(WaitTime);
        _isSpawning = true;

        while (_isSpawning)
        {
            _pool.Get();

            yield return delay;
        }
    }

    private void OnRelease(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody cubeRigidbody))
        {
            cubeRigidbody.isKinematic = true;
        }
        if (cube.TryGetComponent(out Renderer renderer))
        {
            renderer.material.color = _defaultColor;
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
