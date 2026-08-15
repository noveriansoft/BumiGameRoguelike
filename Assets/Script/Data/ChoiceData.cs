using System;
using UnityEngine;


[Serializable]
public class ChoiceData
{
    public string choiceText;

    [Range(0, 100)]
    public int successChance = 70;

    public OutcomeData successOutcome;
    public OutcomeData failureOutcome;

    //public int fuelChange;
    //public int truckChange;
    //public int cargoChange;
}
