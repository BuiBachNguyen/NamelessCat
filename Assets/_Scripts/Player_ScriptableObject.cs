using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "New Data", menuName = "Data/PlayerData")]
public class Player_ScriptableObject : ScriptableObject
{

    public int numberOfMemory = 0;
    public int maxlevel = 1;
    public int level = 1;
    public bool isDead;
    public int indexOfSkin = 0;
    public bool AudioIsOn = false;
    public List<SpriteLibraryAsset> _assets;
    
}
