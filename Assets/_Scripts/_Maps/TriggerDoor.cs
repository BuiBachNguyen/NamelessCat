using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    [SerializeField] DoorButton[] buttons;

    Collider2D cl;
    SpriteRenderer sr;

    private void Start()
    {
        cl = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckIsTrigger();
    }
    void CheckIsTrigger()
    {
        foreach (var btn in buttons)
        {
            if (!btn.isTrigger)
            { 
                SetDoor(true);
                return;
            }
        }
        SetDoor(false);
    }

    void SetDoor(bool value)
    {
        cl.enabled = value;
        sr.enabled = value;
    }
}
