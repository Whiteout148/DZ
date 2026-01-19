using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explodeRadius;
    [SerializeField] private float _explodeForce;

    public void Explode()
    {
        List<Rigidbody> objectsToExplode = GetExplodableObjects();

        for (int i = 0; i < objectsToExplode.Count; i++)
        {
            objectsToExplode[i].AddExplosionForce(_explodeForce, transform.position, _explodeRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explodeRadius);

        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].attachedRigidbody != null)
            {
                explodableObjects.Add(hits[i].attachedRigidbody);
            }
        }

        return explodableObjects;
    }
}
