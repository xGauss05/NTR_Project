using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class QuestObjective
{
    public string objectiveName;
    public int requiredAmount;
    public int currentAmount;

    public bool isComplete;

    public void checkProgress()
    {
        isComplete = currentAmount >= requiredAmount;
    }

    public void AddProgress(int amount)
    {
        currentAmount += amount;
        checkProgress();
    }
}

[CreateAssetMenu(fileName = "NewQuest", menuName = "ScriptableObject/Quest")]
[Serializable]
public class QuestSO : ScriptableObject
{
    public string questName;
    [TextArea] public string description;
    public QuestObjective[] objectives;
    public bool isCompleted => AllObjectivesCompleted();

    private bool AllObjectivesCompleted()
    {
        foreach (var objective in objectives)
        {
            if (!objective.isComplete) return false;
        }

        return true;
    }
}