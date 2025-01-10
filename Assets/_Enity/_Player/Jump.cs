using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Jump : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Moving moving;
    [SerializeField] TeleportManager tpManager;
    bool isPressed;
    void Start()
    {
        isPressed = false;
    }
    void Update()
    {
        if (isPressed || Input.GetKeyDown(KeyCode.UpArrow))
        {
            moving.jumpClick = true;
            tpManager.jumpClick = true;
        }
        else
        {
            moving.jumpClick = false;
            tpManager.jumpClick = false;
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
