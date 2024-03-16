using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private IngredientSO ingredientSO;
    private string ingredientName;
    private float ingredientThickness;

    public void SetIngredient(IngredientSO ingredientSO)
    {
        this.ingredientSO = ingredientSO;
        UpdateIngredient();
    }

    private void UpdateIngredient()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = ingredientSO.GetIngredientSprite();
        
        ingredientName = ingredientSO.GetIngredientName();
        ingredientThickness = ingredientSO.GetIngredientThickness();
    }

    public IngredientSO GetIngredientSO()
    {
        return ingredientSO;
    }
}
