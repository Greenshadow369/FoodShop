using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private IngredientSO ingredientSO;

    [Header("Ingredient Info")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    private string ingredientName;
    private float ingredientThickness;

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
