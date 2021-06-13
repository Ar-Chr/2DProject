using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float maxShotsPerMinute;
    [SerializeField] private float velocity;
    [Space]
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shootingPoint;
    [Space]
    [SerializeField] private float shotAttemptWindow;
    [Space]
    [SerializeField] private GameEvent shootPressedEvent;
    [SerializeField] private GameEvent shotEvent;

    private Rigidbody2D playerRigidbody;

    private bool shotAttempt;

    private float shotCooldown;
    private float currentShotCooldown;

    private void Start()
    {
        shotCooldown = 60 / maxShotsPerMinute;
        playerRigidbody = GetComponent<Rigidbody2D>();
        shootPressedEvent.AddListener(Shoot);
    }

    private void Update()
    {
        if (currentShotCooldown > 0)
            currentShotCooldown -= Time.deltaTime;
        else if (shotAttempt)
            Shoot();
    }

    public void Shoot()
    {
        if (currentShotCooldown > 0)
        {
            if (currentShotCooldown < shotAttemptWindow)
                shotAttempt = true;
            return;
        }

        shotAttempt = false;
        currentShotCooldown = shotCooldown;
        shotEvent.Invoke();

        this.DelayAction(() =>
        {
            GameObject projObj = Instantiate(projectile, shootingPoint.position, Quaternion.identity);
            projObj.layer = LayerMask.NameToLayer("Ignore Player");
            projObj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(transform.localScale.x > 0 ? velocity : -velocity, 3f) + playerRigidbody.velocity;
            if (transform.localScale.x < 0)
                projObj.transform.localScale = projObj.transform.localScale.WithXMultBy(-1);
            Destroy(projObj, 4.0f);
        }, 1.0f / 12.0f);
    }
}
