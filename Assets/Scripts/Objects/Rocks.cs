using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : MonoBehaviour
{
    private bool rigidbodiesAdded;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!rigidbodiesAdded && collider.CompareTag("Enemy"))
        {
            AddRigidbodies();
            Destroy(this);
        }
    }

    private void AddRigidbodies()
    {
        rigidbodiesAdded = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.AddComponent<Rigidbody2D>();
        }
    }
}
