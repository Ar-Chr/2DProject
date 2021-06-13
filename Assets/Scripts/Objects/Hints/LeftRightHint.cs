using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightHint : FormatHint
{
    [SerializeField] KeyBinds binds;

    private void Awake()
    {
        inserts = new object[2];
    }

    protected override void UpdateInserts()
    {
        inserts[0] = binds.GoLeft;
        inserts[1] = binds.GoRight;
    }
}
