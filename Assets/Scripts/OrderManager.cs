using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    //[SerializeField] private List<OrderSO> possibleOrderList;
    [SerializeField] private IngredientListSO ingredientListSO;
    [SerializeField] private Transform orderPrefab;
    [SerializeField] private Transform orderGroup;
    private OrderSelectionSystem orderSelectionSystem;
    private List<Order> currentOrderList;
    private List<IngredientSO> availableIngredientSOList;
    private MixingStation mixingStation;

    private void Awake()
    {
        if(TryGetComponent<OrderSelectionSystem>(out OrderSelectionSystem orderSe))
        {
            orderSelectionSystem = orderSe;
        }

        if(GameObject.FindGameObjectWithTag("Mixing Station").TryGetComponent<MixingStation>(out MixingStation mixingStation_))
        {
            mixingStation = mixingStation_;
        }

        //Currently all ingredient in the ListSO is available in game
        availableIngredientSOList = new List<IngredientSO>(ingredientListSO.GetIngredientSOList());
    }

    private void Start()
    {
        currentOrderList = new List<Order>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            
        }
    }
    
    public void AddNewOrder()
    {
        //Instantiate new prefab order
        Transform orderTransform = Instantiate(orderPrefab, orderGroup.position, Quaternion.identity, orderGroup);
        Order order = orderTransform.GetComponent<Order>();
        
        //OrderSO orderSO = possibleOrderList[Random.Range(0, possibleOrderList.Count)];
        List<IngredientSO> mainOrderRandomList = new List<IngredientSO>();

        //Random number of ingredients for order
        int ingredientNum = Random.Range(1, 4);
        
        for(int i = 0; i < ingredientNum; i++)
        {
            //Get a random ingredient
            IngredientSO randomIngre = availableIngredientSOList[Random.Range(0, availableIngredientSOList.Count)];
            //Add that random ingredient
            mainOrderRandomList.Add(randomIngre);
        }

        //Store the new order in a list
        currentOrderList.Add(order);

        //Pass and set new order info
        order.SetRequiredIngredientSO(mainOrderRandomList);
    }

    public void SubmitCurrentDish()
    {
        if(TryVerifyOrder())
        {
            //Resolve order
            ResolveSubmittedOrder(GetSelectedOrder());

            //Empty plate
            mixingStation.EmptyPlate();
        }
    }

    private bool TryVerifyOrder()
    {
        //Check if there is an order
        if(!IsThereOrder())
        {
            return false;
        }

        //Get current dish
        List<Ingredient> dishIngredientList = new List<Ingredient>(mixingStation.GetDish());
        //Turn dish into ingredientSO list
        List<IngredientSO> dishIngredientSOList = new List<IngredientSO>();
        foreach(Ingredient ingre in dishIngredientList)
        {
            dishIngredientSOList.Add(ingre.GetIngredientSO());
        }

        //Get current selected order
        Order order = GetSelectedOrder();
        if(order == null)
        {
            //No order selected
            return false;
        }

        //Turn order into ingredientSO list
        List<IngredientSO> orderIngredientSOList = new List<IngredientSO>();
        foreach(IngredientSO ingreSO in order.GetMainDishIngredientList())
        {
            orderIngredientSOList.Add(ingreSO);
        }
        //dishIngredientSOList.Reverse();

        //Compare order and dish size
        if(dishIngredientSOList.Count != orderIngredientSOList.Count)
        {
            return false;
        }
        
        //Compare order and dish ingredients
        for(int i = 0; i < orderIngredientSOList.Count; i++)
        {
            if(orderIngredientSOList[i].GetIngredientName() != dishIngredientSOList[i].GetIngredientName())
            {
                return false;
            }
        }
        
        //Submitted dish is good
        return true;
    }

    public void ResolveSubmittedOrder(Order order)
    {
        
        //Gain cash

        //Discard current order
        Order discardedOrder = order;
        currentOrderList.Remove(order);

        Destroy(discardedOrder.gameObject);
    }

    public Order GetSelectedOrder()
    {
        return orderSelectionSystem.GetSelectedOrder();
    }

    public void SetSelectedOrder(Order order)
    {
        orderSelectionSystem.SetSelectedOrder(order);
    }

    public Order GetFirstOrder()
    {
        return currentOrderList[0];
    }

    public bool IsThereOrder()
    {
        if(currentOrderList.Count > 0)
        {
            return true;
        }
        return false;
    }
}
