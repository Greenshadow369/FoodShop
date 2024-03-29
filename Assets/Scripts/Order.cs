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

        //Set result sprite for order
        orderUI.SetOrderSprite(orderSprite);
        //Set ingredient sprites fopr order
        foreach(IngredientSO ingredientSO in orderIngredientList)
        {
            orderUI.CreateIngredientSprite(ingredientSO.GetIngredientSprite());
        } 
        
    }
}
