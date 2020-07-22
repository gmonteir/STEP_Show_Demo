using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButton : Interactive
{
    Transform press;
    float pressStartPosition;
    public float animationSpeed = 1;
    public float pressEndPosition;
    public float timeToTurnOff;

    private void Awake()
    {
        press = transform.GetChild(0);
        pressStartPosition = press.localPosition.z;
    }

    private void Start()
    {
        Off.Invoke();
    }

    public override void Interact()
    {
        StopAllCoroutines();
        StartCoroutine(PressButtonAnimation());
        if(timeToTurnOff > 0)
            StartCoroutine(TurnOffTimer());

        base.Interact();
        On.Invoke();
    }

    IEnumerator PressButtonAnimation()
    {
        while (press.localPosition.z > pressEndPosition)
        {
            press.localPosition -= new Vector3(0, 0, Time.deltaTime * animationSpeed);
            yield return null;
        }
        while (press.localPosition.z < pressStartPosition)
        {
            press.localPosition += new Vector3(0, 0, Time.deltaTime * animationSpeed);
            yield return null;
        }
    }

    IEnumerator TurnOffTimer()
    {
        yield return new WaitForSeconds(timeToTurnOff);
        Off.Invoke();
    }
}
