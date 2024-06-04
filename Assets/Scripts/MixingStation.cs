using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientListSO;
    [SerializeField] private Transform ingredientPrefab;
    [SerializeField] private Transform plateGroup;
    [SerializeField] private List<IngredientSO> startingIngredientList;
    private Vector2 startingPos;
    private Vector2 currentPos;
    private int currentSortOrder;

    void Start()
    {
        //Starting position is where the plate is plus starting ingredient thickness
        startingPos = new Vector2(plateGroup.position.x, plateGroup.position.y);
        foreach(IngredientSO ingre in startingIngredientList)
        {
            startingPos = new Vector2(startingPos.x, startingPos.y + ingre.GetIngredientThickness());
        }

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
        //Create new ingredient
        Transform ingredient = Instantiate(ingredientPrefab, plateGroup.position, Quaternion.identity, plateGroup);
        
        //Move position up according to thickness and set ingredient there
        currentPos = new Vector2(currentPos.x, currentPos.y + ingredientSO.GetIngredientThickness());
        ingredient.position = currentPos;

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
                ingredients.Add(ingre);
            }
        }
        return ingredients;
    }
}
