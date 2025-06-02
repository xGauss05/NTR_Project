using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Carmino_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    public bool canInteract { get; set; } = false;

    [SerializeField] NPCConversation dialogue9;

    [SerializeField] QuestSO parlaCarmino;

    public void Interact(Interactor interactor)
    {
        if (QuestManager.Singleton.activeQuests.Contains(parlaCarmino))
            ConversationManager.Instance.StartConversation(dialogue9);
    }
}
