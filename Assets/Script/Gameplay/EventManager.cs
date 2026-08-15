using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    [Header("Events")]
    public List<EventData> events;
    private EventData currentEvent;
    [SerializeField] private GameObject eventPanel;

    [Header("UI")]
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private TMP_Text descriptionText;

    [Header("Result UI")]
    [SerializeField] private GameObject resultPanel;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text resultDescText;
    private bool waitingForContinue;

    [SerializeField] private Button[] choiceButtons;
    [SerializeField] private TMP_Text[] choiceTexts;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Debug.Log("EventManager Start");
        StartCoroutine(FirstEventRoutine());
    }

    public void GenerateEvent()
    {
        List<EventData> availableEvents = new();

        foreach (var evt in events)
        {
            if (evt.allLevels)
            {
                availableEvents.Add(evt);
            }
            else if (
                RunManager.Instance.currentLevel >= evt.minLevel &&
                RunManager.Instance.currentLevel <= evt.maxLevel)
            {
                availableEvents.Add(evt);
            }
        }

        currentEvent = availableEvents[Random.Range(0, availableEvents.Count)];
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

    private void ShowResult(string title, string description)
    {
        resultPanel.SetActive(true);

        resultText.text = title;
        resultDescText.text = description;

        waitingForContinue = true;
    }

    public void SelectChoice(int index)
    {
        ChoiceData choice = currentEvent.choices[index];

        #region old outcome code
        //ResourceManager.Instance.ModifyFuel(choice.fuelChange);
        //ResourceManager.Instance.ModifyTruckCondition(choice.truckChange);
        //ResourceManager.Instance.ModifyCargo(choice.cargoChange);
        #endregion

        bool success = Random.Range(0, 100) < choice.successChance;

        OutcomeData outcome = success ? choice.successOutcome : choice.failureOutcome;
        ResourceManager.Instance.ModifyFuel(outcome.fuelChange);
        ResourceManager.Instance.ModifyTruckCondition(outcome.truckChange);
        ResourceManager.Instance.ModifyCargo(outcome.cargoChange);
        eventPanel.SetActive(false);
        ShowResult(success ? "SUCCESS" : "FAILURE",outcome.resultText);
        Debug.Log(outcome.resultText);

        return;

        //RunManager.Instance.AdvanceStage();

        //if (RunManager.Instance.IsChoosingUpgrade)
        //{
        //    eventPanel.SetActive(false);
        //    return;
        //}

        //if (RunManager.Instance.IsGameFinished)
        //{
        //    eventPanel.SetActive(false);
        //    return;
        //}

        //eventPanel.SetActive(false);
        //StartCoroutine(NextEventRoutine());
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

    public void ContinueAfterResult()
    {
        resultPanel.SetActive(false);

        CheckGameState();
    }

    private void CheckGameState()
    {
        if (ResourceManager.Instance.fuel <= 0)
        {
            RunManager.Instance.GameOver("Out of Fuel","Your truck ran out of fuel!");
            return;
        }

        if (ResourceManager.Instance.truckCondition <= 0)
        {
            RunManager.Instance.GameOver("Truck Destroyed","Your truck was damaged beyond repair!");
            return;
        }

        if (ResourceManager.Instance.cargoIntegrity <= 0)
        {
            RunManager.Instance.GameOver("Cargo Destroyed","The cargo was completely destroyed!");
            return;
        }

        RunManager.Instance.AdvanceStage();

        if (RunManager.Instance.IsChoosingUpgrade)
            return;

        if (RunManager.Instance.IsGameFinished)
            return;

        StartCoroutine(NextEventRoutine());
    }
}
