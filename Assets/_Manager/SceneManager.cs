using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Scene_Manager : MonoBehaviour
{
    [SerializeField] float progress = 0;
    public GameObject LoaderTheme;
    public GameObject LoaderInTheme;

    private void Start()
    {
        LoaderInTheme.SetActive(true);
        LoaderTheme.SetActive(false);
        StartCoroutine(LoadIn_Coroutine());
    }

    public void LoadScene(int index)
    {
        LoaderTheme.SetActive(true);
        StartCoroutine(LoadScene_Coroutine(index));
    }
    public IEnumerator LoadScene_Coroutine(int index)
    {
        int i = 0;
        while(i+1<2)
        {
            i++;
            yield return new WaitForSeconds(1f);
        }
        SceneManager.LoadScene(index);
    }
    public IEnumerator LoadIn_Coroutine()
    {
        int i = 0;
        while (i + 1 < 3)
        {
            i++;
            yield return new WaitForSeconds(1f);
        }
        LoaderInTheme.SetActive(false);
    }

    public void ChooseLevelScene()
    {
        LoadScene(10);
    }

}
