using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    [Header("Resources")]
    public int fuel = 100;
    public int truckCondition = 100;
    public int cargoIntegrity = 100;

    private void Awake()
    {
        Instance = this;
    }

    public void ModifyFuel(int amount)
    {
        fuel += amount;
    }

    public void ModifyTruckCondition(int amount)
    {
        truckCondition += amount;
    }

    public void ModifyCargo(int amount)
    {
        cargoIntegrity += amount;
    }
}
