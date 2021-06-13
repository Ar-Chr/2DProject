using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Spin : MonoBehaviour
{
    [SerializeField] private float angularSpeed;

    private new Rigidbody2D rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.angularVelocity = Mathf.Sign(transform.localScale.x) * angularSpeed;
        //rigidbody.AddTorque(Mathf.Sign(transform.localScale.x) * angularSpeed, ForceMode2D.Impulse);
    }
}
