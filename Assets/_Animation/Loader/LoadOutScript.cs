using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadOutScript : MonoBehaviour
{

    public Player_ScriptableObject Player_Data;
    public void LoadNextScene()
    {
        Player_Data.level += 1;
        SceneManager.LoadScene(Player_Data.level);
    }
}
