using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class LoadInScript : MonoBehaviour
{
    public void SelfDisable()
    {
        gameObject.SetActive(false);
    }
}
