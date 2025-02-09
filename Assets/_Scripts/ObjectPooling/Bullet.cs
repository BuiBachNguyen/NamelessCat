using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    void Update()
    {
        this.transform.position += Vector3.left;
    }

    public float lifetime = 5f;
    public void OnObjectSpawn()
    {
        Invoke(nameof(ReturnToPool), lifetime);
    }
    private void ReturnToPool()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        ReturnToPool();
    }
}
