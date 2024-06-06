using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientButton : MonoBehaviour
{
    [SerializeField] IngredientSO ingredientSO;
    [SerializeField] Button button;
    private MixingStation mixingStation;

    private void Awake() {
        mixingStation = FindObjectOfType<MixingStation>();
    }

    // private void Start() {
    //     button.onClick.AddListener(() => {
    //         mixingStation.CreateIngredient(ingredientSO);
    //     });
    // }

    private void OnMouseDown() {
        mixingStation.CreateIngredient(ingredientSO);
    }
}