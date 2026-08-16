using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;
    public bool IsGameFinished { get; private set; }
    public bool IsChoosingUpgrade { get; set; }

    [Header("Level")]
    public int currentLevel = 1;
    public int maxLevel = 3;

    [Header("Stage")]
    public int currentStage;
    public int stagesPerLevel = 5;

    [Header("End UI")]
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TMP_Text WinLoseText;
    [SerializeField] private TMP_Text endDescText;

    private void Awake()
    {
        Instance = this;
    }

    public void AdvanceStage()
    {
        currentStage++;

        if (currentStage >= stagesPerLevel)
        {
            CompleteLevel();
        }
    }

    void CompleteLevel()
    {
        currentStage = 0;

        if (currentLevel >= maxLevel)
        {
            WinGame();
            return;
        }

        currentLevel++;
        IsChoosingUpgrade = true;
        UpgradeManager.Instance.ShowUpgradePanel();
    }

    void WinGame()
    {
        Debug.Log("WIN");
        IsGameFinished = true;
        winPanel.SetActive(true);
        WinLoseText.text = "Destination Reached";
        endDescText.text = "You successfully delivered the cargo!";
    }

    public void GameOver(string condition, string description)
    {
        IsGameFinished = true;

        winPanel.SetActive(true);

        WinLoseText.text = condition;
        endDescText.text = description;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();

        Debug.Log("Exit Game");
    }
}
