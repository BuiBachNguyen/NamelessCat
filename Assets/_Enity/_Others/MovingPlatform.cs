using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] bool isVertical;
    [SerializeField] float distance;
    [SerializeField] float speed;
    [SerializeField] float currentDistance;
    [SerializeField] int sign;
    void Start()
    {
        currentDistance = distance;
    }


    void Update()
    {
        if( isVertical)
        {
            if(currentDistance <= 0)
            {
                sign *= -1;

                currentDistance = distance;
            }
            currentDistance -= 0.01f ;
            this.transform.position += Vector3.up * speed * sign;
        }
        else
        {
            if (currentDistance <= 0)
            {
                sign *= -1;

                currentDistance = distance;
            }
            currentDistance -= 0.01f ;
            this.transform.position += Vector3.right * speed * sign;
        }        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
