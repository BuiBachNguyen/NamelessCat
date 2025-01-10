using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpecialButton : MonoBehaviour
{
    [SerializeField] TeleportManager TpManager;
    bool isPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || isPressed)
        {
            TpManager.specialClick = true;
        }
    }
}
