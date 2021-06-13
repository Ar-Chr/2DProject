using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    [SerializeField] private AreaTrigger playerDetector;
    [SerializeField] private GameObject protectionAura;

    private Animator anim;
    private Rigidbody2D rb;
    private Health health;
    private PatrolEnemy patrol;
    private Player player;

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Health>();
        player = FindObjectOfType<Player>();
        patrol = GetComponent<PatrolEnemy>();

        health.unitDiedEvent.AddListener(OnDeath);
        health.unitTookDamageEvent.AddListener(OnTakeDamage);

        var melee = GetComponent<MeleeAttack>();
        var eventCatcher = GetComponentInChildren<SkeletonAnimationEventCatcher>();
        eventCatcher.AttackStartEvent.AddListener(OnAttackStart);
        eventCatcher.SwingStartEvent.AddListener(OnSwingStart);
        eventCatcher.CutStartEvent.AddListener(melee.EnableHitCollider);
        eventCatcher.CutEndEvent.AddListener(melee.DisableHitCollider);
        eventCatcher.AttackEndEvent.AddListener(OnAttackEnd);

        playerDetector.triggerEvent.AddListener(() => anim.SetBool("PlayerInAttackArea", true));
        playerDetector.playerLeftAreaEvent.AddListener(() => anim.SetBool("PlayerInAttackArea", false));

        patrol.idleStateSetEvent.AddListener(() => anim.SetBool("IsMoving", false));
        patrol.movingStateSetEvent.AddListener(() => anim.SetBool("IsMoving", true));
    }

    private bool ShouldJump()
    {
        return player.transform.position.y - transform.position.y > 1f;
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * 4.5f, ForceMode2D.Impulse);
    }

    private void EnableProtection()
    {
        protectionAura.SetActive(true);
        health.takesDamage = false;
    }

    private void DisableProtection()
    {
        protectionAura.SetActive(false);
        health.takesDamage = true;
    }

    #region Event handlers

    private void OnTakeDamage()
    {
        anim.SetTrigger("TakeDamage");
        EnableProtection();
    }

    private void OnDeath()
    {
        protectionAura.SetActive(false);
        patrol.enabled = false;
        anim.SetBool("IsDead", true);
    }

    private void OnAttackStart()
    {
        patrol.seesPlayer = true;
        patrol.Stop();
    }

    private void OnAttackEnd()
    {
        patrol.SetIdleTime(1f);
        DisableProtection();
    }

    private void OnSwingStart()
    {
        if (ShouldJump())
            Jump();
    }

    #endregion
}
