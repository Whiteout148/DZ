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
    [SerializeField] private Painter _painter;

    private ObjectPool<Cube> _pool;
    private Coroutine _coroutine;
    private bool _isSpawning = false;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            OnCreate,
            OnGet,
            OnRelease
        );
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
        cube.ResetVelocity();
        cube.Respawned -= OnReturningToPool;
        cube.CollisedFloor -= _painter.OnCollisedFloor;
        _painter.SetDefaultColor(cube);
        cube.gameObject.SetActive(false);
    }

    private void OnReturningToPool(Cube cube)
    {
        _pool.Release(cube);
    }

    private void OnGet(Cube cube)
    {
        cube.gameObject.SetActive(true);
        cube.CollisedFloor += _painter.OnCollisedFloor;
        cube.transform.position = GetRandomPosition();
        cube.ResetVelocity();
        cube.Respawned += OnReturningToPool;
    }

    private Cube OnCreate()
    {
        Cube cube = Instantiate(_cubePrefab, GetRandomPosition(), Quaternion.identity, transform.parent);
        _painter.SetDefaultColor(cube);
         
        return cube;
    }

    private Vector3 GetRandomPosition()
    {
        float positionX = UnityEngine.Random.Range(MinSpawnPosition, MaxSpawnPosition);
        float positionZ = UnityEngine.Random.Range(MinSpawnPosition, MaxSpawnPosition);

        return new Vector3(positionX, _spawnHeight, positionZ);
    }
}
