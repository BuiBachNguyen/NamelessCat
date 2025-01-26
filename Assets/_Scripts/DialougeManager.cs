using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public bool isSkip;
    void Start()
    {
    }
    void Update()
    {

    }
    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        CanvasController.SetActive(false);
        DisplayMessage();
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorID];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;
    }

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
