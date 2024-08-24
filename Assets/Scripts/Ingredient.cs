using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    private IngredientSO ingredientSO;

    [Header("Ingredient Info")]
    [SerializeField] private LayerMask ingredientLayerMask;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private string ingredientName;
    private float ingredientThickness;
    

    private void Update()
    {
        if(TryHandleIngredientSelection())
        {
            return;
        }
    }

    private bool TryHandleIngredientSelection()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(ray, ingredientLayerMask);
            if(rayHit.collider != null)
            {
                if(rayHit.transform.TryGetComponent<Ingredient>(out Ingredient ingredient))
                {
                    ingredient.IngredientClicked();

                    return true;
                }
            }
        }
        return false;
    }

    private void IngredientClicked()
    {
        //multiple ingredient get clicked when on plate(error?)
        Debug.Log("ingredient clicked");
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
