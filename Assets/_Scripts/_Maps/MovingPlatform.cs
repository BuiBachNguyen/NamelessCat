using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform posA;
    [SerializeField] Transform posB;
    [SerializeField] float speed = 2.0f;
    Vector2 target;
    void Start()
    {
        target = posB.position;
    }
    
    void Update()
    {
        CheckPosition();
        Moving();
    }
    void CheckPosition()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
            target = posB.position;
        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
            target = posA.position;
    }
    void Moving()
    {
        transform.position = Vector2.MoveTowards(transform.position,  target, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision == null) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision == null) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(posA.position, posB.position); 
    }
}
