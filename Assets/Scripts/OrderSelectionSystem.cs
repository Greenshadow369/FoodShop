using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OrderSelectionSystem : MonoBehaviour
{
    public UnityEvent OrderButtonEvent;
    [SerializeField] private Order selectedOrder;

    private void Start()
    {
        
    }

    private void Update()
    {
        //HandleOrderSelection();
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
