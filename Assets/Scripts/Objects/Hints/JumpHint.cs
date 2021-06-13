using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHint : FormatHint
{
    [SerializeField] KeyBinds binds;

    private void Awake()
    {
        inserts = new object[1];
    }

    protected override void UpdateInserts()
    {
        inserts[0] = binds.Jump;
    }
}
