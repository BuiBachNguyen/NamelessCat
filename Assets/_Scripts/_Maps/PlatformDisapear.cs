using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlatformDisapear : MonoBehaviour
{
    private SpriteRenderer objectRenderer;
    private Collider2D objectCollider;
    private Animator _anim;
    void Start()
    {
        objectRenderer = GetComponent<SpriteRenderer>();
        objectCollider = GetComponent<Collider2D>();
        _anim = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Got");
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(DisappearAndRespawn());
            Debug.Log("calll");
        }
    }

    IEnumerator DisappearAndRespawn()
    {
        _anim.SetBool("isStay", false);
        _anim.SetBool("isTrigger", true);
        yield return new WaitForSeconds(2f);
        objectCollider.enabled = false;
        _anim.SetBool("isTrigger", false);

        yield return new WaitForSeconds(5f);
        objectCollider.enabled = true;
        _anim.SetBool("isStay", true);
    }
}
