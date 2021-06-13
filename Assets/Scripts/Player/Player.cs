using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameEvent playerDiedEvent;
    [SerializeField] private GameEvent playerReachedFinishEvent;
    [Space]
    [SerializeField] private IntVariable score;

    private Health health;
    private PlayerAnimationEventCatcher eventCatcher;
    private Animator anim;

    private void Start()
    {
        health = GetComponent<Health>();
        eventCatcher = GetComponentInChildren<PlayerAnimationEventCatcher>();
        anim = GetComponentInChildren<Animator>();
        score.Value = 0;

        health.unitDiedEvent.AddListener(playerDiedEvent.Invoke);
        eventCatcher.shieldRaisedEvent.AddListener(() => health.AddImmunity(DamageTypes.Projectile));
        playerReachedFinishEvent.AddListener(() => health.takesDamage = false);
    }

    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("KnightShield"))
            health.RemoveImmunity(DamageTypes.Projectile);
    }

    public void TakeScore(int score)
    {
        this.score.Value += score;
    }    
}
