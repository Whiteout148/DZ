using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private const int MinSpawnCount = 2;
    private const int MaxSpawnCount = 6;
    private const int MaxSpawnChance = 100;

    private static int s_chanceToSpawn = MaxSpawnChance;

    [SerializeField] private Painter _painter;

    public void Spawn(GameObject objectToSpawn)
    {
        if (s_chanceToSpawn >= UserUtils.GetRandomNumber(0, MaxSpawnChance))
        {
            int spawnCount = UserUtils.GetRandomNumber(MinSpawnCount, MaxSpawnCount);

            for (int i = 0; i < spawnCount; i++)
            {
                SpawnCube(objectToSpawn);
            }
        }

        s_chanceToSpawn /= 2;
    }

    private void SpawnCube(GameObject objectToClone)
    {
        GameObject spawnedCube = Instantiate(objectToClone, objectToClone.transform.position, Quaternion.identity);
        spawnedCube.transform.localScale = objectToClone.transform.localScale / 2;
        spawnedCube.GetComponent<Renderer>().material.color = _painter.GetRandomColor();
    }
}
