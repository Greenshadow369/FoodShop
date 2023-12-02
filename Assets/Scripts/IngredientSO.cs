using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "Scriptable Object/IngredientSO", order = 0)]
public class IngredientSO : ScriptableObject 
{
    [SerializeField] Sprite ingredientSprite;
    [SerializeField] private string ingredientName;
}
