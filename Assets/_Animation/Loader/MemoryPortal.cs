using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemoryPortal : MonoBehaviour
{
    _SceneManager sceneManager;
    [SerializeField] Animator anim;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Claimed", true);
            sceneManager.SetActiveLoadOut();
        }
    }
}
