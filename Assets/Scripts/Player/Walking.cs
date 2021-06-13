using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Walking : MonoBehaviour
{
    [SerializeField] private BoolGameEvent runningEvent;
    [SerializeField] private BoolGameEvent shieldRaisedEvent;
    [SerializeField] private GameEvent goLeftPressedEvent;
    [SerializeField] private GameEvent goRightPressedEvent;
    [Space]
    [SerializeField] private float baseSpeed;

    private float speed;

    private new Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        speed = baseSpeed;
        shieldRaisedEvent.AddListener((raised) => speed = raised ? 0 : baseSpeed);
        goLeftPressedEvent.AddListener(() => Walk(false));
        goRightPressedEvent.AddListener(() => Walk(true));
    }

    public void Walk(bool right)
    {
        if (speed > 1e-2)
        {
            runningEvent.Invoke(right);
            rigidbody.velocity =
                new Vector2(speed * (right ? 1 : -1), rigidbody.velocity.y);
        }
    }
}
