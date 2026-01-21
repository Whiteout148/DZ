using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;

    private void OnEnable()
    {
        _raycaster.HittedCube += OnInteractWithCube;
    }

    private void OnDisable()
    {
        _raycaster.HittedCube -= OnInteractWithCube;
    }

    private void OnInteractWithCube(BombCube cube)
    {
        _spawner.AddObjectToOperations(cube);

        if (cube.TryToDivide())
        {
            List<BombCube> objectsToExplode = _spawner.GetSpawnedClones();
            _exploder.Explode(cube, objectsToExplode);
        }

        _spawner.DestroyCube();
    }
}
