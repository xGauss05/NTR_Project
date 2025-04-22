using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Singleton { get; private set; }

    public List<QuestSO> activeQuests = new List<QuestSO>();

    // Events ------------------------------------------------------------------------------------------
    public UnityEvent OnQuestListChanged = new UnityEvent();
    public UnityEvent OnQuestProgressUpdated = new UnityEvent();
    public UnityEvent OnQuestCompletion = new UnityEvent();

    void Awake()
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
            OnQuestListChanged.Invoke();
        }
    }

    public void RemoveQuest(QuestSO quest)
    {
        if (activeQuests.Contains(quest))
        {
            activeQuests.Remove(quest);
            Debug.Log($"Quest removed: {quest.questName}");
            OnQuestListChanged.Invoke();
        }
    }

    public void ReportProgress(string objectiveName)
    {
        List<QuestSO> removeQuests = new List<QuestSO>();

        foreach (var quest in activeQuests)
        {
            foreach (var objective in quest.objectives)
            {
                if (objective.objectiveName == objectiveName && !objective.isComplete)
                {
                    objective.AddProgress(1);
                    Debug.Log($"Progress added to {objectiveName}: {objective.currentAmount}/{objective.requiredAmount}");
                    OnQuestProgressUpdated.Invoke();
                }
            }

            if (quest.isCompleted)
            {
                removeQuests.Add(quest);
            }
        }

        foreach (var quest in removeQuests)
        {
            RemoveQuest(quest);
            Debug.Log($"Quest completed: {quest.questName}");
            OnQuestCompletion.Invoke();
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
                    OnQuestProgressUpdated.Invoke();
                }
            }
        }
    }


}