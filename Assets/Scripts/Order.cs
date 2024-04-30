using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    private OrderUI orderUI;

    [Header("Order Info")]
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

    //Use for adding individual ingredientSO
    public void AddRequiredIngredientSO(IngredientSO ingredientSO)
    {
        mainDishIngredientList.Add(ingredientSO);
        UpdateOrder();
    }

    //Use for setting a new list of ingredientSO
    public void SetRequiredIngredientSO(List<IngredientSO> ingredientSOlist)
    {
        //Clear all current ingredients in the order
        mainDishIngredientList.Clear();

        //Add new ingredientSOs to list
        foreach(IngredientSO ingredientSO in ingredientSOlist)
        {
            mainDishIngredientList.Add(ingredientSO);
        }
        
        UpdateOrder();
    }

    public List<IngredientSO> GetMainDishIngredientList()
    {
        return mainDishIngredientList;
    }

    private void UpdateOrder()
    {
        UpdateOrderUI();
    }

    private void UpdateOrderUI()
    {
        //Set result sprite for order
        orderUI.CreateResultIngredientSprite(mainDishIngredientList);

        //Set ingredient sprites for order
        foreach(IngredientSO ingredientSO in mainDishIngredientList)
        {
            orderUI.CreateIngredientSprite(ingredientSO.GetIngredientSprite());
        }
    }
}
