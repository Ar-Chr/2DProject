using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Pickupable
{
    [SerializeField] private int score;

    protected override void OnPickup(Collider2D other)
    {
        var player = other.GetComponent<Player>();
        if (player != null)
        {
            player.TakeScore(score);
        }
    }
}
