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
        Transform ingredient = Instantiate(orderPrefab, orderGroup.position, Quaternion.identity, orderGroup);
    }
}
