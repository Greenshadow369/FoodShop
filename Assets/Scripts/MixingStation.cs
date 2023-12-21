using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientList;
    [SerializeField] private Transform ingredientPrefab;
    [SerializeField] private Transform plate;
    private Vector2 startingPos;
    private Vector2 currentPos;
    private int currentSortOrder;

    void Start()
    {
        currentPos = new Vector2(startingPos.x, startingPos.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform CreateIngredient(IngredientSO ingredientSO)
    {
        Transform ingredient = Instantiate(ingredientPrefab, plate.position, Quaternion.identity, plate);
        ingredient.position = currentPos;

        //Move position up according to thickness
        currentPos = new Vector2(currentPos.x, currentPos.y + ingredientSO.GetIngredientThickness());

        //Sort in order
        SpriteRenderer spriteRenderer = ingredient.GetComponent<SpriteRenderer>();
        currentSortOrder++;
        spriteRenderer.sortingOrder = currentSortOrder;

        ingredient.GetComponent<Ingredient>().SetIngredient(ingredientSO);
        return ingredient;
    }

    public void EmptyPlate()
    {
        DiscardIngredient();
        ResetPosition();
    }

    private void DiscardIngredient()
    {
        foreach (Transform child in plate)
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
}
