using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    private OrderUI orderUI;
    private OrderSO orderSO;

    [SerializeField] private Image orderImage;
    private List<IngredientSO> mainDishIngredientList;

    private void Awake()
    {
        mainDishIngredientList = new List<IngredientSO>();
        orderUI = GetComponent<OrderUI>();
    }
    private void Start()
    {
        
    }

    // public void SetOrderSO(OrderSO orderSO)
    // {
    //     this.orderSO = orderSO;
    //     UpdateOrder();
    // }

    public void SetRequiredIngredientSO(IngredientSO ingredientSO)
    {
        mainDishIngredientList.Add(ingredientSO);
        UpdateOrder();
    }

    public List<IngredientSO> GetMainDishIngredientList()
    {
        return mainDishIngredientList;
    }

    public OrderSO GetOrderSO()
    {
        return orderSO;
    }

    private void UpdateOrder()
    {
        //mainDishIngredientList = orderSO.GetOrderIngredientList();
        orderImage.sprite = mainDishIngredientList[0].GetIngredientSprite();
        UpdateOrderUI();
    }

    private void UpdateOrderUI()
    {
        Sprite orderSprite = orderImage.sprite;

        //Set result sprite for order
        orderUI.SetOrderSprite(orderSprite);
        //Set ingredient sprites fopr order
        foreach(IngredientSO ingredientSO in mainDishIngredientList)
        {
            orderUI.CreateIngredientSprite(ingredientSO.GetIngredientSprite());
        } 
        
    }
}
