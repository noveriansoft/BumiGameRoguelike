using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance;

    public int currentStage;
    public int maxStage = 5;

    private void Awake()
    {
        Instance = this;
    }

    public void AdvanceStage()
    {
        currentStage++;

        if (currentStage >= maxStage)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("WIN");
    }
}
