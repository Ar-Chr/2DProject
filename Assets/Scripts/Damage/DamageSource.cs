using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] DamageDealer damageDealer;

    private HashSet<GameObject> damagedObjects;

    private void Start()
    {
        damagedObjects = new HashSet<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (damagedObjects.Contains(other.gameObject))
            return;

        damagedObjects.Add(other.gameObject);
        var health = other.GetComponent<Health>();
        if (health != null)
        {
            if (health.takesDamage && damageDealer.DestroyOnDamage)
                Destroy(gameObject);
            health.TakeDamage(damageDealer);
        }
    }

    private void FixedUpdate()
    {
        damagedObjects.Clear();
    }
}
