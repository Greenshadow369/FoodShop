using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Order : MonoBehaviour
{
    [Header("Order Info")]
    [SerializeField] List<IngredientSO> defaultIngredientBottomList;
    [SerializeField] List<IngredientSO> defaultIngredientTopList;

    private OrderUI orderUI;
    private List<IngredientSO> mainDishIngredientList;

    private void Awake()
    {
        mainDishIngredientList = new List<IngredientSO>();
        orderUI = GetComponent<OrderUI>();
    }
    private void Update()
    {
        //transform.localScale.Scale(new Vector3(2,2,2));
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

    public List<IngredientSO> GetDefaultIngredientBottomList()
    {
        return defaultIngredientBottomList;
    }

    public List<IngredientSO> GetDefaultIngredientTopList()
    {
        return defaultIngredientTopList;
    }

    private void UpdateOrder()
    {
        UpdateOrderUI();
    }

    private void UpdateOrderUI()
    {
        //Set result sprite for order
        orderUI.CreateResultSprite(mainDishIngredientList);

        //Set reuired ingredient sprites for order
        orderUI.CreateRequirementSprite(mainDishIngredientList);
    }
}
