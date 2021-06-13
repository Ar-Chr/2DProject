using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamageSource : MonoBehaviour
{
    [SerializeField] DamageDealer damageDealer;
    [SerializeField] private bool requiresMinVelocity;
    [SerializeField] private float minVelocity;

    private Rigidbody2D rb;

    private HashSet<GameObject> damagedObjects;

    private void Start()
    {
        damagedObjects = new HashSet<GameObject>();
        if (requiresMinVelocity)
            rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (requiresMinVelocity && collision.relativeVelocity.sqrMagnitude < Mathf.Pow(minVelocity, 2))
            return;

        if (damagedObjects.Contains(collision.gameObject))
            return;

        damagedObjects.Add(collision.gameObject);
        var health = collision.collider.GetComponent<Health>();
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
