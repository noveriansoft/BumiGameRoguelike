using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [Header("Resources Now")]
    public int fuel = 100;
    public int truckCondition = 100;
    public int cargoIntegrity = 100;

    [Header("Max Resources")]
    public int maxFuel = 100;
    public int maxTruckCondition = 100;
    public int maxCargoIntegrity = 100;

    [Header("UI")]
    [SerializeField] private TMP_Text fuelText;
    [SerializeField] private TMP_Text truckText;
    [SerializeField] private TMP_Text cargoText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
    }

    public void ModifyFuel(int amount)
    {
        fuel += amount;
        UpdateUI();
    }

    public void AddMaxFuel(int amount)
    {
        maxFuel += amount;
        fuel += amount;
        UpdateUI();
    }

    public void ModifyTruckCondition(int amount)
    {
        truckCondition += amount;
        UpdateUI();
    }

    public void ModifyCargo(int amount)
    {
        cargoIntegrity += amount;
        UpdateUI();
    }

    public void RepairTruck(int amount)
    {
        truckCondition += amount;

        if (truckCondition > maxTruckCondition)
            truckCondition = maxTruckCondition;

        UpdateUI();
    }

    public void AddMaxTruck(int amount)
    {
        maxTruckCondition += amount;
        truckCondition += amount;

        UpdateUI();
    }

    public void AddMaxCargo(int amount)
    {
        maxCargoIntegrity += amount;
        cargoIntegrity += amount;

        UpdateUI();
    }

    private void UpdateUI()
    {
        fuelText.text = $"Fuel: {fuel} / {maxFuel}";
        truckText.text = $"Truck Condition: {truckCondition} / {maxTruckCondition}";
        cargoText.text = $"Cargo Integrity: {cargoIntegrity} / {maxCargoIntegrity }";
    }

    public bool IsDead()
    {
        return fuel <= 0 || truckCondition <= 0;
    }
}
