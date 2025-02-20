using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    float lifetime = 10f;
    [SerializeField] float speed = 2f;
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
    public void OnObjectSpawn()
    {
        Invoke(nameof(ReturnToPool), lifetime);
    }
    private void ReturnToPool()
    {
        this.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ReturnToPool();
    }
}
