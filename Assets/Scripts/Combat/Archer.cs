using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] private GameObject arrow;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float arrowSpeed;
    [SerializeField] private float shotCooldown;

    private float currentShotCooldown;
    private Player player;
    private Animator anim;
    private Health health;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        anim = GetComponent<Animator>();
        health = GetComponent<Health>();
        health.unitDiedEvent.AddListener(() => anim.SetBool("IsDead", true));
    }

    private void Update()
    {
        currentShotCooldown += Time.deltaTime;
        if (currentShotCooldown >= shotCooldown)
        {
            currentShotCooldown = 0;
            anim.SetTrigger("Attack");
        }
    }

    private void Shoot()
    {
        float horDistance = player.transform.position.x - transform.position.x;
        float vertDistance = player.transform.position.y + Mathf.Abs(0.035f * horDistance) - transform.position.y;
        float angle = Mathf.Atan2(vertDistance, horDistance);

        var arrowObj = Instantiate(arrow, shotPoint.position, Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg));
        arrowObj.GetComponent<Rigidbody2D>().velocity = arrowObj.transform.right * arrowSpeed;
        arrowObj.layer = LayerMask.NameToLayer("IgnoreEnemies");
        Destroy(arrowObj, 2.5f);
    }
}
