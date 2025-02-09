using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Cannon : MonoBehaviour
{
    ObjectPooler pooler;
    [SerializeField] Transform firePoint;
    float fireRating = 1f;
    void Start()
    {
        pooler = ObjectPooler.Instance;
        if (pooler == null)
            Debug.LogError("ObjectPooler instance is NULL!");
        StartCoroutine(Fire());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Fire()
    {
        while (true)
        {
            yield return new WaitForSeconds(fireRating);
            Shooting();
        }
    }
    void Shooting()
    {
        GameObject cannonball = pooler.SpawnFromPool("Boom", firePoint.transform.position, firePoint.transform.rotation);
        if (cannonball == null) return;

    }
}
