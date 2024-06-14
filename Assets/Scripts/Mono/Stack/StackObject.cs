using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class StackObject : MonoBehaviour
{
    [SerializeField] private float _rekoverTime;

    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }


    public void Pickup()
    {
        Destroy(_rigidbody);
        _collider.enabled = false;
    }

    public void Drop()
    {
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _rigidbody.useGravity = true;
        _rigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _collider.enabled = true;
    }
}