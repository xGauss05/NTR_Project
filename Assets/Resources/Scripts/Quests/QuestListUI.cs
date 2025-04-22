using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestListUI : MonoBehaviour
{

    [SerializeField] GameObject questItemPrefab;
    [SerializeField] GameObject content;

    

    List<GameObject> currentQuestItems = new List<GameObject>();

    void Start()
    {
        // Initialize events
        QuestManager.Singleton.OnQuestListChanged.AddListener(UpdateUI);
        QuestManager.Singleton.OnQuestProgressUpdated.AddListener(UpdateUI);
        QuestManager.Singleton.OnQuestCompletion.AddListener(UpdateUI);

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
            GameObject questItem = Instantiate(questItemPrefab, content.transform);
            TextMeshProUGUI questText = questItem.GetComponentInChildren<TextMeshProUGUI>();

            string fullText = $"{quest.questName}\n{quest.description}";

            //foreach (var obj in quest.objectives)
            //{
            //    fullText += $"- {obj.objectiveName}: {obj.currentAmount}/{obj.requiredAmount}\n";
            //}

            questText.text = fullText;
            currentQuestItems.Add(questItem);
        }

        Canvas.ForceUpdateCanvases();
        LayoutRebuilder.ForceRebuildLayoutImmediate(content.GetComponent<RectTransform>());
    }
}
