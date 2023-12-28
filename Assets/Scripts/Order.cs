using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    private OrderUI orderUI;

    private void Awake()
    {
        orderUI = GetComponent<OrderUI>();
    }
    private void Update()
    {
        
    }
}
