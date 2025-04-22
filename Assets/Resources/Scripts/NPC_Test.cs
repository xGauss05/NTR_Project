using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC_Test : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    [SerializeField] NPCConversation conversationToShow;

    public void Interact(Interactor interactor)
    {
        Debug.Log("Doing action: " + interactText);
        ConversationManager.Instance.StartConversation(conversationToShow);
    }
}
