using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MemoryPortal : MonoBehaviour
{
    [SerializeField] private Scene_Manager _manager;
    [SerializeField] private Animator anim;

    public Players_ScriptableObject PlayerData;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetBool("Claimed", true);
            PlayerData.Level++;
            _manager.LoadScene(PlayerData.Level);
        }
    }
}
