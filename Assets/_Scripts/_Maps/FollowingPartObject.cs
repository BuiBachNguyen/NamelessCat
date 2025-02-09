using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingPartObject : MonoBehaviour
{
    [SerializeField] Transform[] Points;
    [SerializeField] float speed;
    int index;
    void Start()
    {
        if (Points.Length > 0)
            transform.position = Points[index].position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Points.Length == 0) return;

        transform.position = Vector2.MoveTowards(transform.position, Points[index].position, speed * Time.deltaTime);

        // Use Vector2.Distance to compare positions
        if (Vector2.Distance(transform.position, Points[index].position) < 0.000001f)
        {
            index = (index + 1) % Points.Length; // Automatically loops
        }
    }
}
