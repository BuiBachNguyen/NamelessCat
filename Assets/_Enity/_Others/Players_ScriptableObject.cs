using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Data", menuName = "Data/PlayerData")]
public class Players_ScriptableObject : ScriptableObject
{

    public int NumberOfMemory;
    public int Level;
    public bool isDead;

}
