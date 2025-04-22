using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestListUI : MonoBehaviour
{

    [SerializeField] GameObject questItemPrefab;
    [SerializeField] Transform questListContent;

    List<GameObject> currentQuestItems = new List<GameObject>();

    void Start()
    {
        // Initialize events
        QuestManager.Singleton.OnQuestListChanged.AddListener(UpdateUI);
        QuestManager.Singleton.OnQuestProgressUpdated.AddListener(UpdateUI);

        UpdateUI();
    }

    public void UpdateUI()
    {
        QuestManager qManager = QuestManager.Singleton;

        // Clean UI
        foreach (var item in currentQuestItems)
        {
            Destroy(item);
        }
        currentQuestItems.Clear();

        // Create new elements inside the list
        foreach (var quest in qManager.activeQuests)
        {
            GameObject questItem = Instantiate(questItemPrefab, questListContent);
            TextMeshProUGUI questText = questItem.GetComponentInChildren<TextMeshProUGUI>();

            string fullText = $"{quest.questName}";
            //string description = $"{quest.description}";

            //foreach (var obj in quest.objectives)
            //{
            //    fullText += $"- {obj.objectiveName}: {obj.currentAmount}/{obj.requiredAmount}\n";
            //}

            questText.text = fullText;
            currentQuestItems.Add(questItem);
        }
    }
}
