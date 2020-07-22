using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactive
{
    Transform handle;
    public bool leverPulled;

    public float upperAngle;
    public float lowerAngle;
    public float animationSpeed = 1;
    float t;

    private void Awake()
    {
        handle = transform.GetChild(0);
    }

    private void Start()
    {
        if (!leverPulled)
            handle.localEulerAngles = new Vector3(upperAngle, 0, 0);
        else
            handle.localEulerAngles = new Vector3(lowerAngle, 0, 0);

        if (leverPulled)
            On.Invoke();
        else
            Off.Invoke();
    }

    private void Update()
    {
        t += animationSpeed * (leverPulled ? 1 : -1) * Time.deltaTime;
        t = Mathf.Clamp01(t);
        handle.localEulerAngles = Vector3.Lerp(new Vector3(upperAngle, 0, 0), new Vector3(lowerAngle, 0, 0), t);
    }

    public override void Interact()
    {
        leverPulled = !leverPulled;

        if (leverPulled)
            On.Invoke();
        else
            Off.Invoke();

        base.Interact();
    }
}
