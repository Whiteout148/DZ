using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacter : MonoBehaviour
{
    [SerializeField] private Raycaster _raycaster;
    [SerializeField] private Spawner _spawner;

    private void OnEnable()
    {
        _raycaster.OnHitCube += InteractWithCube;
    }

    private void OnDisable()
    {
        _raycaster.OnHitCube -= InteractWithCube;
    }

    private void InteractWithCube()
    {
        GameObject cube = _raycaster.GetHittedObject();

        _spawner.Spawn(cube);
        cube.GetComponent<Exploder>().Explode();
        Destroy(cube);
    }
}
