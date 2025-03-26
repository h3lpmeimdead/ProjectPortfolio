using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Boid_Movement : MonoBehaviour
{
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _speed = 5;
    private void FixedUpdate()
    {
        _velocity = Vector2.Lerp(_velocity, transform.forward.normalized * _speed, Time.fixedDeltaTime);
        transform.position += _velocity * Time.deltaTime;
    }
}
