using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour, IDataPersistance
{
    public Player_ScriptableObject Pdata;

    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Giữ lại GameManager khi load scene mới
        }
        else
        {
            Destroy(gameObject); // Nếu đã có một instance khác, hủy đối tượng mới
        }
    }
    void Update()
    {
        if(Pdata.maxlevel < Pdata.level )  Pdata.maxlevel = Pdata.level;
    }

    //void Start()
    //{
    //    Pdata.numberOfMemory = 0;
    //    Pdata.maxlevel = 1;
    //    Pdata.level = 1;
    //    Pdata.indexOfSkin = 0;
    //    Pdata.AudioIsOn = true;
    //}

    public void LoadData(GameData data)
    {
        Pdata.numberOfMemory = data.NumberOfMemmory;
        Pdata.level = data.currentLevel - 1;
        Pdata.maxlevel = data.maxLevel - 1;
        Pdata.indexOfSkin = data.indexOfSkin;
        Pdata.AudioIsOn = data.AudioIsOn;
        Debug.Log("XUAT ne");
    }

    public void SaveData(ref GameData data)
    {
        data.NumberOfMemmory = Pdata.numberOfMemory;
        data.maxLevel = Pdata.maxlevel;
        data.currentLevel = Pdata.level + 1;
        data.indexOfSkin = Pdata.indexOfSkin;
        data.AudioIsOn = Pdata.AudioIsOn;

    }
}
