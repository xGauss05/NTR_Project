using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Singleton { get; private set; }

    public List<QuestSO> activeQuests = new List<QuestSO>();

    private void Awake()
    {
        #region Singleton

        if (Singleton != null && Singleton != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Singleton = this;
        }
        DontDestroyOnLoad(this.gameObject);

        #endregion Singleton
    }

    public void AddQuest(QuestSO quest)
    {
        if (!activeQuests.Contains(quest))
        {
            activeQuests.Add(quest);
            Debug.Log($"Quest added: {quest.questName}");
        }
    }

    public void ReportProgress(string objectiveName, int amount)
    {
        foreach (var quest in activeQuests)
        {
            foreach (var objective in quest.objectives)
            {
                if (objective.objectiveName == objectiveName && !objective.isComplete)
                {
                    objective.AddProgress(amount);
                    Debug.Log($"Progress added to {objectiveName}: {objective.currentAmount}/{objective.requiredAmount}");
                }
            }
        }
    }
}