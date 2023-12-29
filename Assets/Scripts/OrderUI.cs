using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private Image order;
    [SerializeField] private Image ingredient;

    public void SetOrderSprite(Sprite sprite)
    {
        order.sprite = sprite;
    }

    public void SetIngredientSprite(Sprite sprite)
    {
        ingredient.sprite = sprite;
    }
}
