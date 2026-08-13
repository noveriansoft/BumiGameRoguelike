using UnityEngine;

[CreateAssetMenu(menuName = "Game/Event")]
public class EventData : ScriptableObject
{
    public string eventTitle;
    public string description;

    public ChoiceData[] choices;
}
