using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class DataPersistanceManager : MonoBehaviour
{

    [Header("File storage config")]
    [SerializeField] private string fileName;
    private FileDataHandler dataHandler;

    private List<IDataPersistance> dataPersistanceObjects;
    public static DataPersistanceManager Instance { get; private set; }
    [SerializeField] private bool useEncryption;
    private GameData gameData;

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

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath,fileName, useEncryption);
        this.dataPersistanceObjects = FindAllDataPersistanceObjects();
        LoadGame();
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        this.gameData = dataHandler.Load();

        if(this.gameData == null)
        {
            Debug.Log("No data was found");
            NewGame();
        }
        foreach(var data in dataPersistanceObjects)
        {
            data.LoadData(gameData);
        }
    }

    public void SaveGame()
    {
        foreach(var data in dataPersistanceObjects)
        {
            data.SaveData(ref gameData);
        }
        dataHandler.Save(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>()
                .OfType<IDataPersistance>();
        return new List<IDataPersistance> (dataPersistanceObjects);
    }

}
