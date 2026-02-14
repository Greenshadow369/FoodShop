using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private IngredientSO ingredientSO;

    [Header("Ingredient Info")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    private string ingredientName;
    private float ingredientThickness;
    private List<IngredientSO.IngredientRecipe> ingredientRecipeList= new List<IngredientSO.IngredientRecipe>();
    private FoodStation currentStation;

    public void IngredientClicked()
    {
        Debug.Log(ingredientName);
        TriggerIngredient();
    }

    public void TriggerIngredient()
    {
        //Consider where the ingredient should go next and check for conditions to do so
        if (ingredientRecipeList.Count > 0)
        {
            var recipe = ingredientRecipeList[0];
            FoodStationSO targetFoodStationSO = recipe.foodStationSO;
            
            //If the ingredient is already at the target station, no need to proceed
            if (currentStation != null && currentStation.GetFoodStationSO() == targetFoodStationSO)
            {
                return;
            }

            //Change to new ingredient, if there is no designated ingredient, it will stay the same
            IngredientSO targetIngredientSO = recipe.ingredientSO ?? ingredientSO;

            var foodStationList = FindObjectsByType<FoodStation>(FindObjectsSortMode.None).ToList<FoodStation>();
            foreach (FoodStation foodSt in foodStationList)
            {
                if (foodSt.GetFoodStationSO() == targetFoodStationSO)
                {
                    if (!foodSt.IsActionValid(this.GetIngredientSO()))
                    {
                        //Action invalid
                        return;
                    }

                    //Pass recipe info to station; let station handle cooking logic
                    foodSt.ReceiveIngredient(this, recipe);
                    //Only set ingredientSO immediately if not a cooking step, if requiresCooking, station will handle SetIngredientSO after timer
                    if (!recipe.requiresCooking)
                        SetIngredientSO(targetIngredientSO);
                    //ingredientRecipeList.RemoveAt(0);
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

    public float GetIngredientThickness()
    {
        return ingredientThickness;
    }

    public void SetCurrentStation(FoodStation station)
    {
        currentStation = station;
    }


}
