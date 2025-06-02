using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Sofia_Manager : MonoBehaviour, IInteractable
{
    [SerializeField] string interactText;
    public string interactableText => interactText;

    public bool canInteract { get; set; } = false;

    [SerializeField] NPCConversation dialogue2;

    //Optional dialogues
    [SerializeField] List<NPCConversation> optionalDialogues;

    [SerializeField] QuestSO parlaAmbLaSofia;
    [SerializeField] QuestSO reportaProgres;

    public void Interact(Interactor interactor)
    {
        if (QuestManager.Singleton.activeQuests.Contains(parlaAmbLaSofia))
            ConversationManager.Instance.StartConversation(dialogue2);

        if (QuestManager.Singleton.activeQuests.Contains(reportaProgres))
            SelectOptionalDialogue();
    }

    void SelectOptionalDialogue()
    {
        int nextDialogue = Random.Range(0, optionalDialogues.Count);

        ConversationManager.Instance.StartConversation(optionalDialogues[nextDialogue]);

        optionalDialogues.RemoveAt(nextDialogue);

        canInteract = false;
    }
}
