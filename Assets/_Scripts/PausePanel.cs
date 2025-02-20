using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject Button;
    [SerializeField] _SceneManager _scManager;
    public void PauseGame()
    {
        Panel.SetActive(true);
        Time.timeScale = 0;
        Button.SetActive(false);
    }
    public void ResumeGame()
    {
        Panel.SetActive(false);
        Time.timeScale = 1;
        Button.SetActive(true);
    }
    public void ReLoadGame()
    {
        Time.timeScale = 1;
        _scManager.ReloadingSceneWhenDie();
    }
    public void Home()
    {
        Time.timeScale = 1;
        _scManager.LoadSelectedScene(6);
    }

}
