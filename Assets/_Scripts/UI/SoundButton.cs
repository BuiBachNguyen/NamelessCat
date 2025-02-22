using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] Player_ScriptableObject pData;
    [SerializeField] GameObject optionButton;
    [SerializeField] GameObject panel;

    [SerializeField] GameObject Skinpanel;
    public void MuteOrUnMute()
    {
        pData.AudioIsOn = !pData.AudioIsOn;
    }


    public void OpenSelectSkinPanel()
    {
        Skinpanel.SetActive(true);
        panel.SetActive(false);
    }
    public void CloseSelectSkinPanel()
    {
        panel.SetActive(true);
        Skinpanel.SetActive(false);
    }

    public void SelectSkin( int index)
    {
        pData.indexOfSkin = index;
        CloseSelectSkinPanel();
    }

    public void OpenPanel()
    {
        panel.SetActive(true);
        optionButton.SetActive(false);
    }
    public void ClosePanel()
    {
        optionButton.SetActive(true);
        panel.SetActive(false);
    }

}
