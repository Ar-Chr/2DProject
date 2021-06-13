using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;

    private float xOffset;

    void Start()
    {
        xOffset = transform.position.x - target.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(target.position.x + xOffset, transform.position.y, transform.position.z);
    }
}
