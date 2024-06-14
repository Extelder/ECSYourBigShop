using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct StackComponent
{
    public int numberOfObjects;
    public List<StackObject> objectsInStack;

    public Transform stackStartPlace;
    public Vector3 dropMoveOffset;
    public float stackPadding;
}