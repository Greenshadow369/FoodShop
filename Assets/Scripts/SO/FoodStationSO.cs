using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FoodStationSO", menuName = "Scriptable Object/FoodStationSO")]
public class FoodStationSO : ScriptableObject
{
    [SerializeField] private int maxIngredientHold = 0;

    public int GetMaxIngredientHoldNum()
    {
        return maxIngredientHold;
    }
}
