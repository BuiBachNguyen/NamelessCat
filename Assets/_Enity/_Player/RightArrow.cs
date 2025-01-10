using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RightArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Moving moving;
    bool isPressed;
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || isPressed)
        {
            moving.rightClick = true;
        }
        else
        {
            moving.rightClick = false;
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
