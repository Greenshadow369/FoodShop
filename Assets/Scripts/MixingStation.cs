using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientList;
    [SerializeField] private Transform ingredientPrefab;
    [SerializeField] private Transform plateGroup;
    private Vector2 startingPos;
    private Vector2 currentPos;
    private int currentSortOrder;

    void Start()
    {
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

    public Transform CreateIngredient(IngredientSO ingredientSO)
    {
        Transform ingredient = Instantiate(ingredientPrefab, plateGroup.position, Quaternion.identity, plateGroup);
        ingredient.position = currentPos;

        //Move position up according to thickness
        currentPos = new Vector2(currentPos.x, currentPos.y + ingredientSO.GetIngredientThickness());

        //Sort in order
        SpriteRenderer spriteRenderer = ingredient.GetComponent<SpriteRenderer>();
        currentSortOrder++;
        spriteRenderer.sortingOrder = currentSortOrder;

        ingredient.GetComponent<Ingredient>().SetIngredientSO(ingredientSO);
        return ingredient;
    }

    public void EmptyPlate()
    {
        DiscardIngredient();
        ResetPosition();
        ResetSortOrder();
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

    public List<Ingredient> GetDish()
    {
        List<Ingredient> ingredients = new List<Ingredient>();
        foreach(Transform trans in plateGroup)
        {
            if(trans.TryGetComponent<Ingredient>(out Ingredient ingre))
            {
                ingredients.Add(ingre);
            }
        }
        return ingredients;
    }
}
