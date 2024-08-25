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

    [System.Serializable]
    public class IngredientRecipe
    {
       public FoodStationSO foodStationSO;
       public IngredientSO ingredientSO;
    }

    [SerializeField] private List<IngredientRecipe> ingredientRecipeList;

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
    
    public List<IngredientRecipe> GetIngredientRecipeList()
    {
        return ingredientRecipeList;
    }
}
