using UnityEngine;

[CreateAssetMenu(menuName = "Game/Upgrade")]
public class UpgradeData : ScriptableObject
{
    public string upgradeName;
    public string description;

    public UpgradeType upgradeType;
    public int value;
}
