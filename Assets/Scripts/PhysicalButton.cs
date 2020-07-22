using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalButton : Interactive
{
    public override void Interact()
    {
        print("Pressed Button");

        base.Interact();
    }
}
