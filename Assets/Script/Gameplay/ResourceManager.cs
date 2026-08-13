using TMPro;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [Header("Resources")]
    public int fuel = 100;
    public int truckCondition = 100;
    public int cargoIntegrity = 100;

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

    private void UpdateUI()
    {
        fuelText.text = $"Fuel: {fuel}";
        truckText.text = $"Truck: {truckCondition}";
        cargoText.text = $"Cargo: {cargoIntegrity}";
    }

    public bool IsDead()
    {
        return fuel <= 0 || truckCondition <= 0;
    }
}
