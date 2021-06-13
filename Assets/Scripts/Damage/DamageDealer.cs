using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewDamageDealer", menuName = "Scriptable Objects/Damage Dealer")]
public class DamageDealer : ScriptableObject
{
    public float Damage;
    public bool DestroyOnDamage;
    public DamageTypes Type;
}

public enum DamageTypes
{
    Melee,
    Projectile
}
