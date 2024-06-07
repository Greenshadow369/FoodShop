using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientListSO;
    [SerializeField] private Transform ingredientPrefab;
    [SerializeField] private Transform plateGroup;
    [SerializeField] private IngredientSO starterIngredient;
    [SerializeField] private IngredientSO finalizeIngredient;
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
                    IngredientSO ing = ingre.GetIngredientSO();
                    Debug.Log(ing);
                }
            }
        }
    }

    public void IngredientButtonClicked(IngredientSO ingredientSO)
    {
        //If this is the starter ingredient then dish is started
        if(starterIngredient.GetIngredientName() != ingredientSO.GetIngredientName() ^ isDishStarted)
        {
            return;
        }

        if(isDishFinished)
        {
            //Dish is already finished
            return;
        }

        CreateIngredient(ingredientSO);
    }

    public Transform CreateIngredient(IngredientSO ingredientSO)
    {
        //Create new ingredient
        Transform ingredient = Instantiate(ingredientPrefab, plateGroup.position, Quaternion.identity, plateGroup);
        
        //Move position up according to thickness and set ingredient there
        ingredient.position = currentPos;
        currentPos = new Vector2(currentPos.x, currentPos.y + ingredientSO.GetIngredientThickness());
        

        //Sort in order
        SpriteRenderer spriteRenderer = ingredient.GetComponent<SpriteRenderer>();
        currentSortOrder++;
        spriteRenderer.sortingOrder = currentSortOrder;

        ingredient.GetComponent<Ingredient>().SetIngredientSO(ingredientSO);

        //Dish is started (whether it is starter ingredient or subsequent ingredients)
        isDishStarted = true;

        //If this is the finalize ingredient then dish is finished
        if(finalizeIngredient.GetIngredientName() == ingredientSO.GetIngredientName())
        {
            isDishFinished = true;
        }

        return ingredient;
    }

    public void EmptyPlate()
    {
        DiscardIngredient();
        ResetPosition();
        ResetSortOrder();
        isDishStarted = false;
        isDishFinished = false;
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

    public List<Ingredient> GetDish()
    {
        List<Ingredient> ingredients = new List<Ingredient>();
        foreach(Transform trans in plateGroup)
        {
            if(trans.TryGetComponent<Ingredient>(out Ingredient ingre))
            {
                //Ignore ingredient if it is the finalize ingredient
                if(ingre.GetIngredientName() == finalizeIngredient.GetIngredientName())
                {
                    continue;
                }

                //Ignore ingredient if it is the starter ingredient
                if(ingre.GetIngredientName() == finalizeIngredient.GetIngredientName())
                {
                    continue;
                }
                
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
