using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateController : MonoBehaviour
{
    [SerializeField] private GameEvent playerDiedEvent;
    [SerializeField] private BoolGameEvent runningEvent;
    [SerializeField] private BoolGameEvent shieldRaisedEvent;
    [SerializeField] private GameEvent playerReachedFinishEvent;
    [SerializeField] private GameEvent shotEvent;
    [Space]
    [SerializeField] private GameEvent goLeftPressedEvent;
    [SerializeField] private GameEvent goRightPressedEvent;
    [SerializeField] private GameEvent jumpEvent;
    [Space]
    [SerializeField] private BoolVariable onGround;

    private Animator animator;

    private bool isRunning;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();

        playerDiedEvent.AddListener(() => animator.SetBool("Dead", true));
        shieldRaisedEvent.AddListener((raised) => animator.SetBool("ShieldUp", raised));
        runningEvent.AddListener((right) =>
        {
            transform.localScale = transform.localScale
                .WithX(Mathf.Abs(transform.localScale.x))
                .WithXMultBy(right ? 1 : -1);
            isRunning = true;
        });
        playerReachedFinishEvent.AddListener(() =>
        {
            animator.SetBool("ShieldUp", false);
            animator.SetBool("Running", false);
        });

        shotEvent.AddListener(() => animator.SetTrigger("Attack"));
        jumpEvent.AddListener(() => animator.SetTrigger("Jump"));
    }

    private void LateUpdate()
    {
        animator.SetBool("OnGround", onGround);
        animator.SetBool("Running", isRunning);
        isRunning = false;
    }
}
