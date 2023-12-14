using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientList;
    [SerializeField] private Transform ingredientPrefab;
    private Transform currentPos;

    void Start()
    {
        currentPos = transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform CreateIngredient(IngredientSO ingredientSO)
    {
        Transform ingredient = Instantiate(ingredientPrefab, currentPos.position, Quaternion.identity);
        //Move position up according to thickness
        currentPos.position = new Vector2(currentPos.position.x, currentPos.position.y + ingredientSO.GetIngredientThickness());
        
        ingredient.GetComponent<Ingredient>().SetIngredient(ingredientSO);
        return ingredient;
    }
}
