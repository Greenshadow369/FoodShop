using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using DG.Tweening;

public class OrderSelectionSystem : MonoBehaviour
{
    [SerializeField] private Order selectedOrder;
    public UnityEvent OrderButtonEvent;
    private OrderManager orderManager;

    private void Awake()
    {
        if(TryGetComponent<OrderManager>(out OrderManager orderManager_))
        {
            orderManager = orderManager_;
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
