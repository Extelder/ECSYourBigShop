using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Voody.UniLeo;

public class RemoveFromStackButton : MonoBehaviour
{
    public void ButtonPressed()
    {
        WorldHandler.GetWorld().SendMessage(new RemoveObjectOutStackEvent());
    }
}