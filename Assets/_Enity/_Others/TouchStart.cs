using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchStart : MonoBehaviour
{
    [SerializeField] Scene_Manager Scene_Manager;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Scene_Manager.LoadScene(1);
        }
    }
}
