using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * this is a special scriptable object that allows for values to be outside of scenes
 * having values outside of scenes doesnt tie it down and allows it to run anywhere
 * this also allows me to use this script for many different projects, and it will even work
 * when the scene is changed or stopped.
 */

[CreateAssetMenu]
public class Float_Values : ScriptableObject, ISerializationCallbackReceiver
{
    public float firstValue;

    [HideInInspector]
    public float DurationValue;

    public void OnAfterDeserialize() 
    {
        DurationValue = firstValue;
    }

    public void OnBeforeSerialize() 
    {
    
    }
}
