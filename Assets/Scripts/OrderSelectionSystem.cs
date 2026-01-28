using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class OrderSelectionSystem : MonoBehaviour
{
    [SerializeField] private Order selectedOrder;
    [Header("References")]
    [SerializeField] private OrderManager orderManager;

    public UnityEvent OrderButtonEvent;
    

    private void Awake()
    {
        if (orderManager == null)
        {
            Debug.LogError(
                $"[{name} | {GetType().Name}] OrderManager reference is required but not assigned.", this
            );
        }
    }
    private void Update() {
        //Auto select first order if none selected
        if(selectedOrder == null && orderManager.GetCurrentOrderList().Count > 0)
        {
            Order firstOrder = orderManager.GetFirstOrder();
            SetSelectedOrder(firstOrder);
        }
    }

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
