using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    [SerializeField] IngredientSO ingredientSO;
    [SerializeField] Transform ingredientPrefab;


    private MixingStation mixingStation;

    private void Awake() {
        if(GameObject.FindGameObjectWithTag("Mixing Station").TryGetComponent<MixingStation>(out MixingStation mixingStation_))
        {
            mixingStation = mixingStation_;
        }
    }

    private void OnMouseDown() {
        mixingStation.IngredientButtonClicked(ingredientSO);
    }

    private void IngredientButtonClicked()
    {
        //Create new ingredient
        //Transform ingredient = Instantiate(ingredientPrefab, ingredientSpawnPoint.position, Quaternion.identity, ingredientSpawnPoint);
    }
}