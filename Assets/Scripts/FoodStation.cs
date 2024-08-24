using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FoodStation will provide basic functions such as storing and operating
//FoodStationSO will provide detailed functions such grilling, pouring drink or slicing 
public class FoodStation : MonoBehaviour
{
    private List<IngredientListSO> currentIngredientList;
    [SerializeField] private FoodStationSO foodStationSO;
    
}
