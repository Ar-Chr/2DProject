using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : Trigger
{
    [SerializeField] private Health trackedHealth;

    private new void Start()
    {
        base.Start();
        trackedHealth.unitDiedEvent.AddListener(triggerEvent.Invoke);
    }
}