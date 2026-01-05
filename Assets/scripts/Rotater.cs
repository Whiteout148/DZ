using UnityEngine;

public class Rotater : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _rotateCount;

    private void Update()
    {
        Rotating();   
    }

    private void Rotating()
    {
        transform.Rotate(new Vector3(0f, _rotateCount, 0f) * _rotateSpeed * Time.deltaTime);
    }
}
