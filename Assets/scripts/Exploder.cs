using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Exploder : MonoBehaviour
{   
    public void Explode(BombCube objectToExplode, List<BombCube> explodableObjects)
    {
        for (int i = 0; i < explodableObjects.Count; i++)
        {
            if (explodableObjects[i].TryGetComponent(out Rigidbody explodableObject))
            {
                explodableObject.AddExplosionForce(objectToExplode.ExplosionForce, objectToExplode.transform.position, objectToExplode.ExplosionRadius);
            }
        }
    }

    public void SphereExplode(BombCube objectToExplode)
    {
        List<Rigidbody> explodableObjects = GetExplodableObjects(objectToExplode);

        for (int i = 0; i < explodableObjects.Count; i++)
        {
            explodableObjects[i].AddExplosionForce(objectToExplode.ExplosionForce, objectToExplode.transform.position, objectToExplode.ExplosionRadius);
        }
    }

    private List<Rigidbody> GetExplodableObjects(BombCube explosionCenter)
    {
        Collider[] hits = Physics.OverlapSphere(explosionCenter.transform.position, explosionCenter.ExplosionRadius);

        List<Rigidbody> explodableObjects = new List<Rigidbody>();

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i].TryGetComponent<BombCube>(out BombCube cube))
            {
                if (cube.TryGetComponent(out Rigidbody rigidbody))
                {
                    explodableObjects.Add(rigidbody);
                }
            }
        }

        return explodableObjects;
    }
}
