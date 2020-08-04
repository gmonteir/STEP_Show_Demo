using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnterSpaceEvent : MonoBehaviour
{
    public bool triggerOnlyOnce = true;
    public bool triggered;
    public UnityEvent OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if(triggered && triggerOnlyOnce)
            return;

        triggered = true;
        OnEnter.Invoke();
    }
}
