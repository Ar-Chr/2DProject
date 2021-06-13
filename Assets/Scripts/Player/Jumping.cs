using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumping : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [Space]
    [SerializeField] private float rayLength;
    [SerializeField] private float raySpace;
    [SerializeField] private LayerMask layerMask;
    [Space]
    [SerializeField] private GameEvent jumpPressedEvent;
    [SerializeField] private GameEvent jumpEvent;
    [Space]
    [SerializeField] private BoolVariable onGround;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        jumpPressedEvent.AddListener(TryJump);
    }

    void FixedUpdate()
    {
        onGround.Value = IsOnGround();
        DrawRays();
    }

    public void TryJump()
    {
        if (onGround)
            Jump();
    }

    private void Jump()
    {
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        jumpEvent.Invoke();
    }

    private bool IsOnGround()
    {
        if (RayHit(Vector3.zero))
            return true;
        for (int i = 1; i <= 3; i++)
        {
            if (RayHit(Vector3.right * i * raySpace))
                return true;
            if (RayHit(Vector3.left * i * raySpace))
                return true;
        }
        return false;
    }

    private bool RayHit(Vector3 offset)
    {
        return Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, layerMask).collider != null;
    }

#if UNITY_EDITOR
    private void DrawRays()
    {
        DrawRay(Vector3.zero);
        for (int i = 1; i <= 3; i++)
        {
            DrawRay(Vector3.right * i * raySpace);
            DrawRay(Vector3.left * i * raySpace);
        }
    }

    private void DrawRay(Vector3 offset)
    {
        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, Color.red);
    }
#endif
}
