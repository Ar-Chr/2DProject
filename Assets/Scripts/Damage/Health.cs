using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{    
    public UnityEvent unitTookDamageEvent;
    public UnityEvent unitDiedEvent;

    public bool takesDamage;

    [SerializeField] protected HashSet<DamageTypes> ignoredDamage;

    [SerializeField] protected float maxHealth;
    [SerializeField] protected FloatReference currentHealth;

    public bool isAlive => currentHealth.Value > 0;
    public float healthPercentage => currentHealth / maxHealth;

    private void Start()
    {
        ignoredDamage = new HashSet<DamageTypes>();
        currentHealth.Value = maxHealth;
        takesDamage = true;
        OnStart();
    }

    protected virtual void OnStart() { }

    public virtual void TakeDamage(DamageDealer dealer)
    {
        if (!takesDamage)
            return;

        if (ignoredDamage.Contains(dealer.Type))
            return;

        currentHealth.Value = Mathf.Clamp(currentHealth.Value - dealer.Damage, 0, maxHealth);
        unitTookDamageEvent.Invoke();
        
        if (!isAlive)
            Die();
    }

    public void AddImmunity(DamageTypes type)
    {
        ignoredDamage.Add(type);
    }

    public void RemoveImmunity(DamageTypes type)
    {
        ignoredDamage.Remove(type);
    }

    private void Die()
    {
        takesDamage = false;
        unitDiedEvent.Invoke();
    }
}