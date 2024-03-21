using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OrderSelectionSystem : MonoBehaviour
{
    [SerializeField] private Order selectedOrder;
    [SerializeField] private LayerMask orderLayerMask;

    private void Start()
    {
        
    }

    private void Update()
    {
        //HandleOrderSelection();
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

    public void SetSelectedOrder(Order order)
    {
        selectedOrder = order;

        //SetSelectedAction(unit.GetAction<SpinAction>());
        //OnSelectedOrderChanged?.Invoke(this, EventArgs.Empty);
    }

    public Order GetSelectedOrder()
    {
        return selectedOrder;
    }
}
