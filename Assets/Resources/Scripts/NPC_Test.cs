using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPC_Test : MonoBehaviour, IInteractable
{
    public string interactableText => "Talk to Manolo";

    public void Interact(Interactor interactor)
    {
        Debug.Log("Talking to Manolo");
        ConversationManager.Instance.StartConversation(GameObject.Find("Conversation test").GetComponent<NPCConversation>());
    }
}
