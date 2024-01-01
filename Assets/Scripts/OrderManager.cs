using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<OrderSO> possibleOrderList;
    [SerializeField] private Transform orderPrefab;
    [SerializeField] private Transform orderGroup;
    private List<OrderSO> currentOrderList;

    private void Start()
    {
        currentOrderList = new List<OrderSO>();
    }
    
    public void AddNewOrder()
    {
        //Instantiate new prefab order
        Transform orderTransform = Instantiate(orderPrefab, orderGroup.position, Quaternion.identity, orderGroup);
        Order order = orderTransform.GetComponent<Order>();
        
        //Get a random order
       OrderSO orderSO = possibleOrderList[Random.Range(0, possibleOrderList.Count)];

        //Store the new order in a list
        currentOrderList.Add(orderSO);
        

        //Pass and set new order info
        order.SetOrder(orderSO);
    }
}
