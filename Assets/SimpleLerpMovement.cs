using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLerpMovement : MonoBehaviour
{
    public bool gotoEnd;
    public float animationTime;
    float t;
    Vector3 startPosition;
    public Vector3 endPosition;
    Vector3 startRotation;
    public Vector3 endRotation;


    private void Awake()
    {
        startPosition = transform.localPosition;
        startRotation = transform.localEulerAngles;
    }

    private void Update()
    {
        if(gotoEnd)
            t += (1 / animationTime) * Time.deltaTime;
        else
            t -= (1 / animationTime) * Time.deltaTime;
        t = Mathf.Clamp01(t);

        transform.localPosition = Vector3.Lerp(startPosition, endPosition, t);
        transform.localRotation = Quaternion.Lerp(Quaternion.Euler(startRotation), Quaternion.Euler(endRotation), t);
    }

    public void ToggleMove()
    {
        gotoEnd = !gotoEnd;
    }
}
