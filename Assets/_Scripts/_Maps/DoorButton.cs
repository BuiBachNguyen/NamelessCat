using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public bool isTrigger;
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
        isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isTrigger", isTrigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrigger = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        isTrigger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
        Debug.Log("LEAVE!!!");
    }
}
