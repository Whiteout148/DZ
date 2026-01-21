using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int ScaleDivider = 2;

    private BombCube _spawnedCube;
    private BombCube _objectToOperations;

    public void AddObjectToOperations(BombCube objectToOperations)
    {
        _objectToOperations = objectToOperations;
    }

    public List<BombCube> GetSpawnedClones()
    {
        List<BombCube> spawnedClones = new List<BombCube>();

        int clonesCount = _objectToOperations.GetRandomClonesCount();

        for (int i = 0; i < clonesCount; i++)
        {
            spawnedClones.Add(GetSpawnedCube());
        }

        return spawnedClones;
    }

    public void DestroyCube()
    {
        Destroy(_objectToOperations.gameObject);
    }

    private BombCube GetSpawnedCube()
    {
        _spawnedCube = Instantiate(_objectToOperations, _objectToOperations.transform.position, Quaternion.identity, _objectToOperations.transform.parent);
        _spawnedCube.transform.localScale = _objectToOperations.transform.localScale / ScaleDivider;
        _spawnedCube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        _spawnedCube.DivideChance();

        return _spawnedCube;
    }
}
