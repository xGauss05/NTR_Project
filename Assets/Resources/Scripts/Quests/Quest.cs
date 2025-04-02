using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewQuest", menuName = "ScriptableObjects/Quest")]
public class QuestSO : ScriptableObject
{
    public enum QuestProgress
    {
        Not_Started,
        Started,
        Completed,
    }

    [System.Serializable]
    public class Quest
    {
        public string name;
        public QuestProgress progress;

        [TextArea(2, 5)]
        public string description;
    }

    public Quest quest;

    public void AddQuest() 
    {
        QuestManager.Singleton.AddQuest(this);
    }
}
