using System;
using UnityEngine;

[Serializable]
public struct StackBlockGeneratorComponent
{
    public Transform generatePlace;
    public StackObject stackObjectPrefab;
    [HideInInspector] public float currentGenerateDelay;
    public float generateDelay;
}