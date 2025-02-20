using UnityEditor.Tilemaps;
using UnityEngine;

public class BigGuy : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] Transform posA;
    [SerializeField] Transform posB;
    Vector2 target;
    Rigidbody2D rb;
    Animation anim; // Not yet use, but will be used
    private bool isFacingRight;
    void Start()
    {
        target = posB.position;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        isFacingRight = false;
    }

    void Update()
    {
        CheckPosition();
        Moving();
    }
    void CheckPosition()
    {
        if (Vector2.Distance(transform.position, posA.position) < 0.1f)
        {
            target = posB.position;
            Flip();
        }
        if (Vector2.Distance(transform.position, posB.position) < 0.1f)
        {
            target = posA.position;
            Flip();
        }
    }
    void Moving()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        isFacingRight = !isFacingRight;
    }
}
