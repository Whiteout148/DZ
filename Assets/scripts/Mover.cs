using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private List<Transform> _places = new List<Transform>();

    public float _speed;
    private int _placeIndex = 0;

    public void Update()
    {
        Move();
    }

    private void Move()
    {
        Transform currentPoint = _places[_placeIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, _speed * Time.deltaTime);

        if (transform.position == currentPoint.position) SwitchPlace();
    }

    private Vector3 SwitchPlace()
    {
        _placeIndex++;

        if (_placeIndex == _places.Count - 1)
            _placeIndex = 0;

        Vector3 currentPosition = _places[_placeIndex].transform.position;
        transform.forward = currentPosition - transform.position;

        return currentPosition;
    }
}
