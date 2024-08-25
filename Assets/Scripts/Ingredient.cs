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
    private List<IngredientSO.IngredientRecipe> ingredientRecipeList;
    
    private void Start()
    {
        ingredientRecipeList = new List<IngredientSO.IngredientRecipe>();
    }

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
                Debug.Log(rayHit.transform);
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

        TriggerIngredient();
    }

    private void TriggerIngredient()
    {
        if(ingredientRecipeList.Count > 0)
        {
            FoodStationSO targetFoodStationSO = ingredientRecipeList[0].foodStationSO;
            IngredientSO targerIngredientSO = ingredientRecipeList[0].ingredientSO;
            List<FoodStation> foodStationList =  FindObjectsByType<FoodStation>(FindObjectsSortMode.None).ToList<FoodStation>();
            
            foreach(FoodStation foodSt in foodStationList)
            {
                if(foodSt.GetFoodStationSO() == targetFoodStationSO)
                {
                    Debug.Log("moved");
                    foodSt.PassIngredient(this);
                    SetIngredientSO(targerIngredientSO);
                }
            }

            ingredientRecipeList.RemoveAt(0);
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

    // public float GetIngredientThickness()
    // {
    //     return ingredientThickness;
    // }


}
