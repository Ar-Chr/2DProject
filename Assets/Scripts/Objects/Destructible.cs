using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : Health
{
    protected override void OnStart()
    {
        unitDiedEvent.AddListener(() => Destroy(gameObject));
    }
}
