using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int ScaleDivider = 2;
    private const int MinClones = 2;
    private const int MaxClones = 6;

    private BombCube _spawnedCube;

    public List<BombCube> SpawnCubes(BombCube cube)
    {
        List<BombCube> spawnedClones = new List<BombCube>();

        for (int i = 0; i < UnityEngine.Random.Range(MinClones, MaxClones); i++)
        {
            spawnedClones.Add(SpawnCube(cube));
        }

        return spawnedClones;
    }

    public void DestroyCube(BombCube cube)
    {
        Destroy(cube.gameObject);
    }

    private BombCube SpawnCube(BombCube cube)
    {
        _spawnedCube = Instantiate(cube, cube.transform.position, Quaternion.identity, cube.transform.parent);
        _spawnedCube.transform.localScale = cube.transform.localScale / ScaleDivider;
        
        if (_spawnedCube.TryGetComponent(out Renderer cubeRenderer))
        {
            cubeRenderer.material.color = UnityEngine.Random.ColorHSV();
        }

        _spawnedCube.ChangeProperties();

        return _spawnedCube;
    }
}
