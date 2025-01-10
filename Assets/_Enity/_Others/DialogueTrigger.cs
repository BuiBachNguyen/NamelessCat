using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject DialogueManager;
    public Message[] messages;
    public Actor[] actors;
    private bool wasPlayed;
    public Animator animator;
    public int WaitTime;
    public void StartDialogue()
    {
        if(wasPlayed) return;
        DialogueManager.SetActive(true);
        FindObjectOfType<DialogueManager>().OpenDialogue(messages, actors);
        wasPlayed = true;
        animator.SetBool("isOn", true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !wasPlayed)
        {
            StartCoroutine("Wait_Coroutine");
        }
    }

    public IEnumerator Wait_Coroutine()
    {
        int i = 0;
        while (i + 1 < WaitTime)
        {
            i++;
            yield return new WaitForSeconds(1f);
        }
        StartDialogue();
    }
}
[System.Serializable]
public class Message
{
    public int actorID;
    public string message;
}
[System.Serializable]
public class Actor
{
    public string name;
    public Sprite sprite;
}
