using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Control_level : MonoBehaviour
{
    [SerializeField] _SceneManager _SceneManager;
    [SerializeField] GameObject panel;
    public void Switch()
    {
        panel.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public void LoadSceneWithNumber(int num)
    {
        _SceneManager.LoadSelectedScene(num);
    }
}
