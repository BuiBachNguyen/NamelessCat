using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Moving : MonoBehaviour
{
    private Vector3 velocity;
    Vector3 inputDirection;
    float acceleration = 1.5f;
    float maxSpeed = 5f;
    //For moving input
    public float delta;
    public bool jumpClick;
    public bool leftClick;
    public bool rightClick;


    public Players_ScriptableObject PlayerData;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] float jumpForce = 7.5f;
    private Rigidbody2D rb;
    [SerializeField] private bool isGrounded = true;
    private Animator anim;
    private float countDownTime = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        moving();
    }
    private void Update()
    {
        flip();
        startCountDown();
        jump();
    }

    public void moving()
    {
        inputDirection = Vector3.zero;
        if (leftClick) { delta = -1.0f; inputDirection += Vector3.left; }
        else if (rightClick) { delta = 1.0f; inputDirection += Vector3.right; }
        else { delta = 0f;}

        Vector3 targetVelocity = inputDirection.normalized * maxSpeed;


        if (targetVelocity.magnitude > 0)
            velocity = Vector3.MoveTowards(velocity, targetVelocity, acceleration * 5 * Time.deltaTime);
        else
            velocity = Vector3.zero;

        transform.Translate(velocity * Time.deltaTime);

    }
    private void jump()
    {
        if ((jumpClick || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && countDownTime == 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
            anim.SetBool("isJumping", true);
            countDownTime = 1f;
        }
        anim.SetFloat("isRunning", Mathf.Abs(delta));
    }
    private void flip()
    {
        if (isFacingRight && delta < 0 || !isFacingRight && delta > 0)
        {
            isFacingRight= !isFacingRight;
            Vector3 Oscale = transform.localScale;
            Oscale.x = Oscale.x * -1;
            transform.localScale = Oscale;
        }
    }
    private void startCountDown()
    {
        if (countDownTime > 0)
            countDownTime -= Time.deltaTime;
        if (countDownTime < 0)
            countDownTime = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }
        if (collision.gameObject.CompareTag("Enermy"))
        {
            PlayerData.isDead = true;
        }
    }
}
