using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class LeftArrow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Moving moving;
    bool isPressed;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || isPressed)
        {
            moving.leftClick = true;
        }
        else
        {
            moving.leftClick = false;
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
