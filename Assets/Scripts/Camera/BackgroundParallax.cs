using System;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] private BackgroundLayer[] layers;

    private Vector3 prev;

    private void Start()
    {
        prev = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 shift = transform.position - prev;
        prev = transform.position;
        foreach (BackgroundLayer layer in layers)
            layer.Move(shift);
    }

    [Serializable]
    private class BackgroundLayer
    {
        [SerializeField] private GameObject background;
        [SerializeField] [Range(0, 1)] private float xMovementShare;
        [SerializeField] [Range(0, 1)] private float yMovementShare;

        public void Move(Vector3 shift)
        {
            background.transform.position = background.transform.position
                .WithXPlus(shift.x * xMovementShare)
                .WithYPlus(shift.y * yMovementShare);
        }
    }
}

