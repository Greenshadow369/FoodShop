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

    // private void HandleOrderSelection()
    // {
    //     if(Input.GetMouseButtonDown(0))
    //     {
    //         if(selectedOrder == null)
    //         {
    //             //No order is currently selected
    //             return;
    //         }

    //         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //         RaycastHit2D rayHit = Physics2D.GetRayIntersection(ray, orderLayerMask);
    //         if(rayHit.collider == null)
    //         {
    //             //No collider at mouse position
    //             return;
    //         }
            
    //         if(rayHit.transform.TryGetComponent<Order>(out Order order))
    //         {
    //             if(selectedOrder == order)
    //             {
    //                 //Order is already selected
    //                 return;
    //             }

    //                 // if(unit is Enemy)
    //                 // {
    //                 //     //Unit is an enemy
    //                 //     return false;
    //                 // }
    //             Debug.Log("yes");
    //             SetSelectedOrder(order);
    //             return;
    //         }
            
    //     }
    // }
}
