using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "OrderSO", menuName = "Scriptable Object/OrderSO")]
public class OrderSO : ScriptableObject
{
    [SerializeField] private List<IngredientSO> orderIngredientList;
    [SerializeField] private Sprite orderSprite;
}
