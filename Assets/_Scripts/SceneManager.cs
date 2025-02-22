using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
public class _SceneManager : MonoBehaviour
{

    [SerializeField] GameObject LoadIn;
    [SerializeField] GameObject LoadOut;
    public Player_ScriptableObject Player_Data;

    private void Start()
    {
        LoadIn.SetActive(true);
        LoadOut.SetActive(false);
    }

    public void SetActiveLoadOut()
    {
        LoadOut.SetActive(true);
    }
    public void ChangeSelectedScene(int indexOfScene)
    {
        SceneManager.LoadScene(indexOfScene);
    }
    public void LoadNextScene()
    {
        Player_Data.level += 1;
        SceneManager.LoadScene(Player_Data.level);
    }
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene(Player_Data.level);
    }
    public void ReloadingSceneWhenDie()
    {
        Player_Data.level-=1;
        SetActiveLoadOut();
    }
    public void LoadSelectedScene(int level)
    {
        level -= 1;
        Player_Data.level = level;
        SetActiveLoadOut();
    }
    public void LOADMENU()
    {
        SceneManager.LoadScene("Select_Level");
    }
}
