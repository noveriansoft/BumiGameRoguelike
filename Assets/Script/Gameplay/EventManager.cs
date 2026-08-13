using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    [Header("Events")]
    public List<EventData> events;
    private EventData currentEvent;
    [SerializeField] private GameObject eventPanel;

    [Header("UI")]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;

    [SerializeField] private Button[] choiceButtons;
    [SerializeField] private TMP_Text[] choiceTexts;

    private void Start()
    {
        Debug.Log("EventManager Start");
        StartCoroutine(FirstEventRoutine());
    }

    public void GenerateEvent()
    {
        currentEvent = events[Random.Range(0, events.Count)];
        Debug.Log(currentEvent.eventTitle);
        UpdateUI();
        eventPanel.SetActive(true);
    }

    private void UpdateUI()
    {
        titleText.text = currentEvent.eventTitle;
        descriptionText.text = currentEvent.description;

        for (int i = 0; i < choiceButtons.Length; i++)
        {
            if (i < currentEvent.choices.Length)
            {
                choiceButtons[i].gameObject.SetActive(true);
                choiceTexts[i].text = currentEvent.choices[i].choiceText;
            }
            else
            {
                choiceButtons[i].gameObject.SetActive(false);
            }
        }
    }

    public void SelectChoice(int index)
    {
        ChoiceData choice = currentEvent.choices[index];

        ResourceManager.Instance.ModifyFuel(choice.fuelChange);
        ResourceManager.Instance.ModifyTruckCondition(choice.truckChange);
        ResourceManager.Instance.ModifyCargo(choice.cargoChange);

        if (ResourceManager.Instance.IsDead())
        {
            Debug.Log("GAME OVER");
            return;
        }

        RunManager.Instance.AdvanceStage();
        eventPanel.SetActive(false);
        StartCoroutine(NextEventRoutine());
    }

    private IEnumerator NextEventRoutine()
    {
        yield return new WaitForSeconds(2f);
        GenerateEvent();
    }

    private IEnumerator FirstEventRoutine()
    {
        yield return new WaitForSeconds(1f);

        GenerateEvent();
    }
}
