using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<OrderSO> possibleOrderList;
    [SerializeField] private Transform orderPrefab;
    [SerializeField] private Transform orderGroup;
    private OrderSelectionSystem orderSelectionSystem;
    private List<Order> currentOrderList;
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
    }

    private void Start()
    {
        currentOrderList = new List<Order>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Order order = orderSelectionSystem.GetSelectedOrder();
            if(order == null)
            {
                return;
            }
            foreach(IngredientSO ingredientSO in order.GetOrderSO().GetOrderIngredientList())
            {
                Debug.Log(ingredientSO.GetIngredientName());
            }
        }
    }
    
    public void AddNewOrder()
    {
        //Instantiate new prefab order
        Transform orderTransform = Instantiate(orderPrefab, orderGroup.position, Quaternion.identity, orderGroup);
        Order order = orderTransform.GetComponent<Order>();
        
        //Get a random order
        OrderSO orderSO = possibleOrderList[Random.Range(0, possibleOrderList.Count)];

        //Store the new order in a list
        currentOrderList.Add(order);
        

        //Pass and set new order info
        order.SetOrderSO(orderSO);
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

        //Order order = orderManager.GetFirstOrder();
        OrderSO orderSO = order.GetOrderSO();   //OrderSO orderSO = Instantiate<OrderSO>(orderManager.GetFirstOrderSO());
        
        //Turn order into ingredientSO list
        List<IngredientSO> orderIngredientSOList = new List<IngredientSO>();
        foreach(IngredientSO ingreSO in orderSO.GetOrderIngredientList())
        {
            orderIngredientSOList.Add(ingreSO);
        }
        dishIngredientSOList.Reverse();

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
