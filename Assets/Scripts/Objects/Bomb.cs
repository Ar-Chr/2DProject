using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject explosion;

    private void OnEnable()
    {
        this.DelayAction(() =>
        {
            var exp = Instantiate(explosion, transform);
            var effector = exp.GetComponent<PointEffector2D>();
            this.DelayAction(() => effector.enabled = false, 0.14f);
            var animator = exp.GetComponent<Animator>();
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }, 3.0f);
    }
}
