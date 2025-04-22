using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Prisioner_tmp_dialogue : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    [SerializeField] NPCConversation dialogue1;
    [SerializeField] NPCConversation dialogue2;
    [SerializeField] ItemSO itemToAcquire;

    public void Interact(Interactor interactor)
    {
        if (!ItemManager.Singleton.CheckItemInPlayer(itemToAcquire))
            ConversationManager.Instance.StartConversation(dialogue1);
        else
            ConversationManager.Instance.StartConversation(dialogue2);
    }
}
