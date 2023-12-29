using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<OrderSO> possibleOrderList;
    [SerializeField] private Transform orderPrefab;
    [SerializeField] private Transform orderGroup;
    private List<OrderSO> currentOrderList;
    
    public void AddNewOrder()
    {
        Transform orderTransform = Instantiate(orderPrefab, orderGroup.position, Quaternion.identity, orderGroup);
        Order order = orderTransform.GetComponent<Order>();
        Debug.Log(possibleOrderList[0] != null);
        currentOrderList.Add(possibleOrderList[0]);
        order.SetOrder(currentOrderList[0]);
    }
}
