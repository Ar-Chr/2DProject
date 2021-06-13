using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameEvent enemyKilledEvent;

    private Health health;

    private void Start()
    {
        health = GetComponent<Health>();
        health.unitDiedEvent.AddListener(enemyKilledEvent.Invoke);
    }
}
