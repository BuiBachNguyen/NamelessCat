using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[CreateAssetMenu(fileName = "New Data", menuName = "Data/PlayerData")]
public class Player_ScriptableObject : ScriptableObject
{

    public int numberOfMemory;
    public int level;
    public bool isDead;
    public List<SpriteLibraryAsset> _assets;
    public int indexOfSkin;

}
