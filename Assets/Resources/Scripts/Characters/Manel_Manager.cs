using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Manel_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    public bool canInteract { get; set; } = false;

    [SerializeField] NPCConversation dialogue3;
    [SerializeField] NPCConversation dialogue8;
    [SerializeField] NPCConversation dialogue10;

    [SerializeField] QuestSO parlaPresCella;
    [SerializeField] QuestSO parlaManelObjectes;
    [SerializeField] QuestSO triaLaFugida;

    public void Interact(Interactor interactor)
    {
        if (QuestManager.Singleton.activeQuests.Contains(parlaPresCella))
            ConversationManager.Instance.StartConversation(dialogue3);

        if (QuestManager.Singleton.activeQuests.Contains(parlaManelObjectes))
            ConversationManager.Instance.StartConversation(dialogue8);

        if (QuestManager.Singleton.activeQuests.Contains(triaLaFugida))
            ConversationManager.Instance.StartConversation(dialogue10);
    }
}
