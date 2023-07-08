using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class FloatVar : ScriptableObject
{
    float value;

    public float Value
    {
        get => value;
    }

    public void Increment(float incVal)
    {
        value += incVal;
    }

    public void Decrement(float incVal)
    {
        Increment(incVal*-1);
    }
}
