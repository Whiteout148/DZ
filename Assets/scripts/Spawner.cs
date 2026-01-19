using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinSpawnCount = 2;
    private const int MaxSpawnCount = 6;

    private static int s_chanceToSpawn = 100;

    public void Spawn()
    {
        int spawnCount = UserUtils.GetRandomNumber(MinSpawnCount, MaxSpawnCount);
        Debug.Log("spawned");

        for (int i = 0; i < spawnCount; i++)
        {
            SpawnCube();
        }

        s_chanceToSpawn--;
    }

    private void SpawnCube()
    {
        GameObject spawnedCube = Instantiate(transform.gameObject, transform.localPosition, Quaternion.identity);
        spawnedCube.transform.localScale = transform.localScale / 2;
    }
}
