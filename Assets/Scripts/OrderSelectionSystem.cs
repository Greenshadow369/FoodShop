using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OrderSelectionSystem : MonoBehaviour
{
    [SerializeField] private Order selectedOrder;
    public UnityEvent OrderButtonEvent;
    public void SetSelectedOrder(Order order)
    {
        selectedOrder = order;
        OrderButtonEvent.Invoke();
    }

    public Order GetSelectedOrder()
    {
        return selectedOrder;
    }
}
