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

    private void Update() {
        if(Input.GetKeyDown(KeyCode.A))
        {
            selectedOrder.GetComponent<RectTransform>().DOAnchorPosX(1500, 0.5f).From().SetEase(Ease.OutQuad);
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
