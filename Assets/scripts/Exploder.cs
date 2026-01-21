using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    public void Explode(BombCube objectToExplode, List<BombCube> explodableObjects)
    {
        for (int i = 0; i < explodableObjects.Count; i++)
        {
            explodableObjects[i].GetComponent<Rigidbody>().AddExplosionForce(_explodeForce, objectToExplode.transform.position, _explodeRadius);
        }
    }
}
