using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LevelHandle : MonoBehaviour
{
    [SerializeField] Player_ScriptableObject pData;
    // Update is called once per frame
    public List<GameObject> btns = new List<GameObject>();
    void Update()
    {
        for (int i = 0; i < btns.Count; i++)
        {
            if (i + 1 <= pData.maxlevel)
            {
                btns[i].SetActive(true);
            }
            else
            {
                btns[i].SetActive(false);
            }
        }
    }
}
