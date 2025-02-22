using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public int NumberOfMemmory;
    public int maxLevel;
    public int currentLevel;
    public int indexOfSkin;
    public bool AudioIsOn;

    //Set default
    public GameData()
    {
        this.NumberOfMemmory = 0;
        this.maxLevel = 1;
        this.currentLevel = 1;
        this.indexOfSkin = 0;
        this.AudioIsOn = true;
    }
}
