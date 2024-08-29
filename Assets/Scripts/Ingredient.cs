using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private IngredientSO ingredientSO;

    [Header("Ingredient Info")]
    [SerializeField] private LayerMask ingredientLayerMask;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private string ingredientName;
    private float ingredientThickness;
    private List<IngredientSO.IngredientRecipe> ingredientRecipeList= new List<IngredientSO.IngredientRecipe>();
    
    private void Start()
    {
        //SetIngredientSO(ing);
    }

    private void OnMouseDown()
    {
        IngredientClicked();
    }

    private void IngredientClicked()
    {
        Debug.Log(ingredientName);
        TriggerIngredient();
    }

    private void TriggerIngredient()
    {
        if(ingredientRecipeList.Count > 0)
        {
            FoodStationSO targetFoodStationSO = ingredientRecipeList[0].foodStationSO;
            IngredientSO targetIngredientSO = ingredientRecipeList[0].ingredientSO;
            List<FoodStation> foodStationList =  FindObjectsByType<FoodStation>(FindObjectsSortMode.None).ToList<FoodStation>();
            
            foreach(FoodStation foodSt in foodStationList)
            {
                if(foodSt.GetFoodStationSO() == targetFoodStationSO)
                {
                    Debug.Log("moved");
                    foodSt.PassIngredient(this);
                    SetIngredientSO(targetIngredientSO);
                }
            }
        }
    }

    public void SetIngredientSO(IngredientSO ingredientSO)
    {
        this.ingredientSO = ingredientSO;
        UpdateIngredient();
    }

    private void UpdateIngredient()
    {
        spriteRenderer.sprite = ingredientSO.GetIngredientSprite();
        
        ingredientName = ingredientSO.GetIngredientName();
        ingredientThickness = ingredientSO.GetIngredientThickness();
        ingredientRecipeList = ingredientSO.GetIngredientRecipeList();
        Debug.Log(ingredientRecipeList != null);
    }

    public IngredientSO GetIngredientSO()
    {
        return ingredientSO;
    }

    // public Sprite GetIngredientSprite()
    // {
    //     return spriteRenderer.sprite;
    // }

    public string GetIngredientName()
    {
        return ingredientName;
    }

    // public float GetIngredientThickness()
    // {
    //     return ingredientThickness;
    // }


}
