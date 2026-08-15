using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    [Header("Data")]
    public List<UpgradeData> allUpgrades;

    [Header("UI")]
    public GameObject upgradePanel;

    public Button[] buttons;
    public TMP_Text[] buttonTexts;

    private UpgradeData[] currentChoices = new UpgradeData[3];

    private void Awake()
    {
        Instance = this;
    }

    public void ShowUpgradePanel()
    {
        upgradePanel.SetActive(true);

        List<UpgradeData> pool = new List<UpgradeData>(allUpgrades);

        for (int i = 0; i < 3; i++)
        {
            int randomIndex = Random.Range(0, pool.Count);

            currentChoices[i] = pool[randomIndex];

            buttonTexts[i].text = currentChoices[i].upgradeName;

            pool.RemoveAt(randomIndex);
        }
    }

    public void SelectUpgrade(int index)
    {
        UpgradeData upgrade = currentChoices[index];
        ApplyUpgrade(upgrade);
        upgradePanel.SetActive(false);
        RunManager.Instance.IsChoosingUpgrade = false;
        EventManager.Instance.GenerateEvent();

        Debug.Log("Upgrade: " + currentChoices[index].upgradeName);
    }

    void ApplyUpgrade(UpgradeData upgrade)
    {
        switch (upgrade.upgradeType)
        {
            case UpgradeType.AddMaxFuel:
                ResourceManager.Instance.AddMaxFuel(upgrade.value);
                break;

            case UpgradeType.FuelRefill:
                ResourceManager.Instance.ModifyFuel(upgrade.value);
                break;

            case UpgradeType.RepairTruck:
                ResourceManager.Instance.RepairTruck(upgrade.value);
                break;

            case UpgradeType.AddMaxCargo:
                ResourceManager.Instance.AddMaxCargo(upgrade.value);
                break;

            case UpgradeType.AddMaxTruck:
                ResourceManager.Instance.AddMaxTruck(upgrade.value);
                break;
        }
    }
}