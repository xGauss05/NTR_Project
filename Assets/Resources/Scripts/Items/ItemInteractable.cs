using UnityEngine;

public class ItemInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO item;

    public string interactableText { get; private set; }
    public bool canInteract { get; set; } = true;

    [SerializeField] Sofia_Manager sofiaManager;
    [SerializeField] private QuestSO sofiaQuest;

    [SerializeField] private QuestSO exploreQuest;
    [SerializeField] private QuestSO manelQuest;

    [SerializeField] private Manel_Manager manelManager;

    void Start()
    {
        interactableText = item.name;
        QuestManager.Singleton.OnQuestCompletedParam.AddListener(CheckEscape);
    }

    public void Interact(Interactor interactor)
    {
        ItemManager.Singleton.GiveItemToPlayer(item);
        gameObject.SetActive(false);

        QuestManager.Singleton.ReportProgress("Investiga la presó");
        
        sofiaManager.canInteract = true;
        QuestManager.Singleton.AddQuest(sofiaQuest);
    }

    void CheckEscape(QuestSO completedQuest)
    {
        if (completedQuest == exploreQuest)
        {
            QuestManager.Singleton.AddQuest(manelQuest);
            manelManager.canInteract = true;
        }
    }
}