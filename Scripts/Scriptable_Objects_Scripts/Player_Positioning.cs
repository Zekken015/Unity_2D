using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Player_Positioning : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 firstValue;
    public Vector2 originalValue;

    public void OnAfterDeserialize()
    {
        firstValue = originalValue;
    }

    public void OnBeforeSerialize()
    {

    }
}
