using UnityEngine;

[CreateAssetMenu(menuName = "Game/Event")]
public class EventData : ScriptableObject
{
    public string eventTitle;
    public string description;
    public bool allLevels = true;
    public int minLevel = 1;
    public int maxLevel = 1;

    public ChoiceData[] choices;
}
