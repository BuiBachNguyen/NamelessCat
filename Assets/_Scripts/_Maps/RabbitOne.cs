using System.Collections;
using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pointA, pointB; // Điểm di chuyển
    public float normalSpeed = 2f;   // Tốc độ bình thường
    public float chaseSpeed = 6f;    // Tốc độ khi phát hiện Player
    public float attackCooldown = 2f; // Thời gian nghỉ sau khi tấn công
    public float detectionRange; // Khoảng cách phát hiện
    public LayerMask playerLayer;    // Layer chứa Player

    private Transform targetPoint;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isChasing = false;
    private bool isAttacking = false;
    private float facing = 1f;

    [SerializeField] _AudioManager _audio;
    void Start()
    {
        _audio = _AudioManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        targetPoint = pointB; // Bắt đầu đi đến B
        Flip();
    }

    void Update()
    {
        if (!isAttacking) // Nếu không đang tấn công
        {
            if (isChasing)
                DetectPlayer(); // Kiểm tra Player liên tục khi đuổi
            else
                Patrol(); // Di chuyển tuần tra nếu không phát hiện Player
        }
    }

    void Patrol()
    {
        float speed = normalSpeed;

        if (Vector2.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            targetPoint = (targetPoint == pointA) ? pointB : pointA;
            Flip();
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Kiểm tra phát hiện Player
        DetectPlayer();
    }

    void DetectPlayer()
    {
        detectionRange = Vector2.Distance(transform.position, targetPoint.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.right * facing, detectionRange, playerLayer);
        if (hit.collider == null) return;
        if (hit.collider.gameObject.CompareTag("Player") && !isAttacking)
        {
            Debug.Log("Phát hiện Player! Lao đến tấn công!");
            isChasing = true;
            StartCoroutine(ChaseAndAttack(hit.collider.transform));
        }
    }

    IEnumerator ChaseAndAttack(Transform player)
    {
        isChasing = true;
        anim.SetBool("isChasing", true);

        // ⏳ Đợi 0.5 giây trước khi lao tới
        yield return new WaitForSeconds(0.5f);
        // Lao nhanh đến Player
        while (Vector2.Distance(transform.position, targetPoint.position) > 0.5f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, chaseSpeed /2 * Time.deltaTime);
            yield return null; // Chờ frame tiếp theo
        }
        _audio.PlaySFX(_audio.RabbitCharge);

        // Khi chạm Player, thực hiện tấn công
        Debug.Log("Tấn công Player!");
        isAttacking = true;
        // ⏳ Đợi 2 giây trước khi tiếp tục tuần tra
        yield return new WaitForSeconds(attackCooldown);

        Debug.Log("Hồi phục, tiếp tục tuần tra.");
        isAttacking = false;
        isChasing = false;
    }
    void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
        facing *= -1;
    }


    void OnDrawGizmos()
    {
        // Hiển thị Raycast trong Scene
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * detectionRange);
    }
    void SetEndChaseAnim()
    {
        anim.SetBool("isChasing", false);
    }
}
