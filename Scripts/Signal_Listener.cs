using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Signal_Listener : MonoBehaviour
{
    public Signal_Send signalSender;
    public UnityEvent signalEvent;
    public void OnSignalRaised()
    {
        signalEvent.Invoke();
    }

    private void OnEnable()
    {
        signalSender.RegisterListener(this);
    }

    private void OnDisable()
    {
        signalSender.DeRegisterListener(this);
    }
}
