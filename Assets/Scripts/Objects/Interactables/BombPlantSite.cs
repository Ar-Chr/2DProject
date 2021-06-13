using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlantSite : Interactable
{
    [SerializeField] private GameObject bomb;
    [SerializeField] private Transform plantPosition;

    protected override void Interact()
    {
        Destroy(gameObject);
        Instantiate(bomb, plantPosition.position, Quaternion.identity);
    }
}
