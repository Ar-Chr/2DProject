using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableBoatMotor : TriggerAction
{
    [SerializeField] private SliderJoint2D sliderJoint;

    public override void Do()
    {
        sliderJoint.useMotor = true;
    }
}
