using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class PatrolEnemy : MonoBehaviour
{
    public UnityEvent idleStateSetEvent;
    public UnityEvent movingStateSetEvent;

    public bool isMoving;
    public bool seesPlayer;
    [Space]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float idleTime;
    private float forgetsAboutPlayerTime = 4f;

    private PatrolStates currentState;
    private float currentIdleTime;
    private float currentSeesPlayerTimer;

    private Rigidbody2D rb;
    private Player player;

    void Start()
    {
        currentSeesPlayerTimer = 0;
        currentState = PatrolStates.Moving;
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        if (seesPlayer)
        {
            currentSeesPlayerTimer += Time.fixedDeltaTime;
            if (currentSeesPlayerTimer >= forgetsAboutPlayerTime)
            {
                seesPlayer = false;
                currentSeesPlayerTimer = 0;
            }
        }

        if (!isMoving)
            return;

        switch (currentState)
        {
            case PatrolStates.Idle:
                currentIdleTime += Time.fixedDeltaTime;
                if (currentIdleTime >= idleTime)
                    SetState(PatrolStates.Moving);
                break;

            case PatrolStates.Moving:
                if (rb.velocity.sqrMagnitude < 0.01f)
                    SetState(PatrolStates.Idle);
                else
                    Move();
                break;
        }
    }

    public void SetIdleTime(float maxIdleTimeMultiplier) => 
        currentIdleTime = idleTime * maxIdleTimeMultiplier;

    public void Stop()
    {
        SetState(PatrolStates.Idle);
    }

    private void Move()
    {
        rb.velocity = rb.velocity.WithX(moveSpeed * transform.right.x);
    }

    private void SetNewRotation()
    {
        if (!seesPlayer)
            transform.Rotate(0, 180, 0);
        else
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles
                .WithY(player.transform.position.x < transform.position.x ? 180 : 0));
    }

    private void SetState(PatrolStates newState)
    {
        currentState = newState;
        switch (newState)
        {
            case PatrolStates.Idle:
                idleStateSetEvent.Invoke();
                break;

            case PatrolStates.Moving:
                movingStateSetEvent.Invoke();
                currentIdleTime = 0;
                SetNewRotation();
                Move();
                break;
        }
    }

    private enum PatrolStates
    {
        Idle,
        Moving
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PatrolStopper"))
            SetState(PatrolStates.Idle);
    }
}