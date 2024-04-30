using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "IngredientSO", menuName = "Scriptable Object/IngredientSO")]
public class IngredientSO : ScriptableObject 
{
    [SerializeField] Sprite ingredientSprite;
    [SerializeField] private string ingredientName;
    [SerializeField] private float ingredientThickness;

    public Sprite GetIngredientSprite()
    {
        return ingredientSprite;
    }

    public string GetIngredientName()
    {
        return ingredientName;
    }

    public float GetIngredientThickness()
    {
        return ingredientThickness;
    }
}
