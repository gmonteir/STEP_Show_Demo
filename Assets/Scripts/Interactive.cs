using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    public UnityEvent Interactions;

    public virtual void Interact()
    {
        Interactions.Invoke();
    }
}
