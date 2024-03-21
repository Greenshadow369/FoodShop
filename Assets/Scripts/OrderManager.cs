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

    private void Awake()
    {
        if(TryGetComponent<OrderSelectionSystem>(out OrderSelectionSystem orderSe))
        {
            orderSelectionSystem = orderSe;
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

    public void ResolveSubmittedOrder()
    {
        
        //Gain cash

        //Discard current order
        Order discardedOrder = currentOrderList[0];
        currentOrderList.RemoveAt(0);
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
