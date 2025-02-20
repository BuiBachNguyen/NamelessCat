using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Cannon : MonoBehaviour
{
    ObjectPooler pooler;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireRating = 5f;
    Animator anim;
    void Start()
    {
        pooler = ObjectPooler.Instance;
        if (pooler == null)
            Debug.LogError("ObjectPooler instance is NULL!");
        anim = GetComponent<Animator>();
        StartCoroutine(Fire());
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
        anim.SetBool("isShooting", true);
        GameObject cannonball = pooler.SpawnFromPool("Boom", firePoint.transform.position, transform.rotation);
    }
    void SetFalse()
    {
        anim.SetBool("isShooting", false);
    }
}
