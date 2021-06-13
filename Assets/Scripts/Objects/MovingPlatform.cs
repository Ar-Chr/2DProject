using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Transform leftPosition;
    [SerializeField] private Transform rightPosition;

    private SliderJoint2D joint;

    private bool movingRight;

    private void Start()
    {
        joint = GetComponent<SliderJoint2D>();
        movingRight = true;
    }

    void FixedUpdate()
    {
        if (joint.useMotor)
            if (NearPosition((movingRight ? rightPosition : leftPosition).position))
            {
                movingRight = !movingRight;
                joint.motor = new JointMotor2D() { motorSpeed = joint.motor.motorSpeed * -1, maxMotorTorque = 10000f };
            }
    }

    private bool NearPosition(Vector3 position)
    {
        return Mathf.Abs(transform.position.x - position.x) < 1e-2;
    }
}
