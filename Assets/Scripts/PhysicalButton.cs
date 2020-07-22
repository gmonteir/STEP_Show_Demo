using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButton : Interactive
{
    Transform press;
    float pressStartPosition;
    public float animationSpeed = 1;
    public float pressEndPosition;

    private void Awake()
    {
        press = transform.GetChild(0);
        pressStartPosition = press.localPosition.z;
    }

    public override void Interact()
    {
        print("Pressed Button");
        StopAllCoroutines();
        StartCoroutine(pressButtonAnimation());

        base.Interact();
    }

    IEnumerator pressButtonAnimation()
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
}
