using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientListSO", menuName = "Scriptable Object/IngredientListSO")]
public class IngredientListSO : ScriptableObject 
{
    [SerializeField] private List<IngredientSO> ingredientList;
    
}
