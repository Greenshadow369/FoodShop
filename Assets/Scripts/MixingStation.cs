using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientListSO;
    [SerializeField] private Transform ingredientPrefab;
    [SerializeField] private Transform plateGroup;
    [SerializeField] private IngredientSO starterIngredient;
    [SerializeField] private IngredientSO finalizeIngredient;
    [SerializeField] private DishStateSO dishStateSO;

    private Vector2 startingPos;
    private Vector2 currentPos;
    private int currentSortOrder;
    private bool isDishStarted = false;
    private bool isDishFinished = false;
    

    void Start()
    {
        //Starting position is where the plate is
        startingPos = new Vector2(plateGroup.position.x, plateGroup.position.y);

        currentPos = new Vector2(startingPos.x, startingPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            foreach(Transform trans in plateGroup)
            {
                if(trans.TryGetComponent<Ingredient>(out Ingredient ingre))
                {
                    String ing = ingre.GetIngredientName();
                    Debug.Log(ing);
                }
            }
        }
    }

    public void PlaceIngredient(Ingredient ingre)
    {
        Transform ingredientTransform = ingre.gameObject.transform;
        
        //Set ingredient and move current position up according to thickness
        ingredientTransform.position = currentPos;
        currentPos = new Vector2(currentPos.x, currentPos.y + ingre.GetIngredientThickness());
        

        //Sort in order
        SpriteRenderer spriteRenderer = ingre.GetComponent<SpriteRenderer>();
        currentSortOrder++;
        spriteRenderer.sortingOrder = currentSortOrder;

        IngredientSO ingreSO = ingre.GetComponent<Ingredient>().GetIngredientSO();

        UpdateDishState(ingreSO);
    }

    private void UpdateDishState(IngredientSO ingredientSO)
    {
        //If this is the starter ingredient then dish is started
        if(starterIngredient.GetIngredientName() == ingredientSO.GetIngredientName())
        {
            dishStateSO.NextState();
        }

        //If this is the finalize ingredient then dish is finished
        if(finalizeIngredient.GetIngredientName() == ingredientSO.GetIngredientName())
        {
            dishStateSO.NextState();
        }
    }

    public void DiscardDish()
    {
        // Play sound when discarding dish
        FindAnyObjectByType<AudioManager>().Play("DiscardDish");
        
        ResetDish();
    }

    //Reset dish to original state
    public void ResetDish()
    {
        DiscardIngredient();
        ResetPosition();
        ResetSortOrder();
        dishStateSO.ResetDishState();
    }

    private void DiscardIngredient()
    {
        foreach (Transform child in plateGroup)
        {
            if(child.tag == "Ingredient")
            {
                Destroy(child.gameObject);
            }  
        }
        //sprite.bounds.min.y
    }

    private void ResetPosition()
    {
        currentPos = startingPos;
    }

    private void ResetSortOrder()
    {
        currentSortOrder = 0;
    }

    public IngredientListSO GetIngredientListSO()
    {
        return ingredientListSO;
    }

    public IngredientSO GetStarterIngredientSO()
    {
        return starterIngredient;
    }

    public List<Ingredient> GetDish()
    {
        //Getting all transform at this station and return ingredients in them as a list
        List<Ingredient> ingredients = new List<Ingredient>();
        foreach(Transform trans in plateGroup)
        {
            if(trans.TryGetComponent<Ingredient>(out Ingredient ingre))
            {
                //Add this ingredient to the list
                ingredients.Add(ingre);
            }
        }
        return ingredients;
    }

    public bool IsDishFinished()
    {
        return isDishFinished;
    }

    public bool IsDishStarted()
    {
        return isDishStarted;
    }
}
