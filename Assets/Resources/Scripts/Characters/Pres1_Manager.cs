using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Pres1_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    public bool canInteract { get; set; } = false;

    [SerializeField] NPCConversation dialogue2A;

    [SerializeField] QuestSO parlaPresApallissat;

    public void Interact(Interactor interactor)
    {
        if (QuestManager.Singleton.activeQuests.Contains(parlaPresApallissat))
            ConversationManager.Instance.StartConversation(dialogue2A);
    }
}
