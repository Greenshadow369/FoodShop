using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private OrderUI orderUI;
    private OrderSO order;

    private void Awake()
    {
        orderUI = GetComponent<OrderUI>();
    }
    private void Start()
    {
        
    }

    public void SetOrder(OrderSO orderSO)
    {
        order = orderSO;
        UpdateOrder();
    }

    private void UpdateOrder()
    {
        UpdateOrderUI();
    }

    private void UpdateOrderUI()
    {
        Sprite orderSprite = order.GetOrderSprite();
        List<IngredientSO> orderIngredientList = order.GetOrderIngredientList();
        Sprite ingredientSprite = orderIngredientList[0].GetIngredientSprite();
        
        orderUI.SetOrderSprite(orderSprite);
        orderUI.SetIngredientSprite(orderSprite);
    }
}
