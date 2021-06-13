using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : TriggerAction
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private int count;
    [Space]
    [Range(-90, 90)] [SerializeField] private float minAngle;
    [Range(-90, 90)] [SerializeField] private float maxAngle;
    [SerializeField] private float minForce;
    [SerializeField] private float maxForce;

    public GameObject SpawnObject => spawnObject;
    public int Count => count;

    public override void Do()
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(spawnObject, spawnPoint.position, Quaternion.identity);
            obj.GetComponent<Rigidbody2D>().AddForce(GetRandomForce(), ForceMode2D.Impulse);
        }
    }

    private Vector3 GetRandomForce()
    {
        float angle = Mathf.Deg2Rad * (90 + Random.Range(minAngle, maxAngle));
        float magnitude = Random.Range(minForce, maxForce);
        return magnitude * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
    }
}