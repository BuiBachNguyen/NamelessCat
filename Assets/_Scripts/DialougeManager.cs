using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public RectTransform backgroundBox;
    public GameObject CanvasController;
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public bool isSkip; // đc skip chưa nè
    void Start()
    {
        isSkip = false;
    }
    void Update()
    {

    }

    //Mở lên
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        CanvasController.SetActive(false);
        DisplayMessage();
    }

    //Hiển thị
    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }
    //Thông điệp kế tiếp
    public void NextMessage()
    {
        activeMessage++;
        if (activeMessage < currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            isSkip = true;
        }
    }
    //Skip qua
    public void SkipDialogue()
    {
        if (!isSkip)
        {
            activeMessage = currentMessages.Length - 1;
            DisplayMessage();
            isSkip = true;
        }
        else
        {
            backgroundBox.gameObject.SetActive(false);
            CanvasController.SetActive(true);
        }

    }

}
