using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MixingStation : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientList;
    [SerializeField] private Transform ingredientPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public Transform CreateIngredient(IngredientSO ingredientSO)
    {
        Transform ingredient = Instantiate(ingredientPrefab, transform);
        ingredient.GetComponent<Ingredient>().SetIngredient(ingredientSO);
        return ingredient;
    }
}
