using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] private GameObject hitCollider;

    public void EnableHitCollider()
    {
        hitCollider.SetActive(true);
    }

    public void DisableHitCollider()
    {
        hitCollider.SetActive(false);
    }
}
