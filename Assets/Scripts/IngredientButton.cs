using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    [SerializeField] IngredientSO ingredientSO;

    private MixingStation mixingStation;

    private void Awake() {
        mixingStation = FindObjectOfType<MixingStation>();
    }

    private void OnMouseDown() {
        mixingStation.IngredientButtonClicked(ingredientSO);
    }
}