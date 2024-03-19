using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private OrderUI orderUI;
    private OrderSO orderSO;

    private void Awake()
    {
        orderUI = GetComponent<OrderUI>();
    }
    private void Start()
    {
        
    }

    public void SetOrderSO(OrderSO orderSO)
    {
        this.orderSO = orderSO;
        UpdateOrder();
    }

    public OrderSO GetOrderSO()
    {
        return orderSO;
    }

    private void UpdateOrder()
    {
        UpdateOrderUI();
    }

    private void UpdateOrderUI()
    {
        Sprite orderSprite = orderSO.GetOrderSprite();
        List<IngredientSO> orderIngredientList = orderSO.GetOrderIngredientList();

        //Set result sprite for order
        orderUI.SetOrderSprite(orderSprite);
        //Set ingredient sprites fopr order
        foreach(IngredientSO ingredientSO in orderIngredientList)
        {
            orderUI.CreateIngredientSprite(ingredientSO.GetIngredientSprite());
        } 
        
    }
}
