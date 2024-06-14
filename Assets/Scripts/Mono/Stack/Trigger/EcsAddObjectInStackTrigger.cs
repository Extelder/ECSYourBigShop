using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

[RequireComponent(typeof(Collider))]
public class EcsAddObjectInStackTrigger : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<StackObject>(out StackObject stackObject))
        {
            Debug.Log(stackObject);
            WorldHandler.GetWorld().SendMessage(new AddObjectInStackEvent()
            {
                StackObject = stackObject
            });
        }
    }
}