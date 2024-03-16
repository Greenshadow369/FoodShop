using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private List<OrderSO> possibleOrderList;
    [SerializeField] private Transform orderPrefab;
    [SerializeField] private Transform orderGroup;
    private List<OrderSO> currentOrderList;
    private MixingStation mixingStation;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Mixing Station").TryGetComponent<MixingStation>(out MixingStation mixingStation_))
        {
            mixingStation = mixingStation_;
        }
    }

    private void Start()
    {
        currentOrderList = new List<OrderSO>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            foreach(OrderSO orderSO in currentOrderList)
            {
                List<IngredientSO> li = orderSO.GetOrderIngredientList();
                foreach(IngredientSO ingredient in li)
                {
                    Debug.Log(ingredient);
                }
            }
        }
    }
    
    public void AddNewOrder()
    {
        //Instantiate new prefab order
        Transform orderTransform = Instantiate(orderPrefab, orderGroup.position, Quaternion.identity, orderGroup);
        Order order = orderTransform.GetComponent<Order>();
        
        //Get a random order
       OrderSO orderSO = possibleOrderList[Random.Range(0, possibleOrderList.Count)];

        //Store the new order in a list
        currentOrderList.Add(orderSO);
        

        //Pass and set new order info
        order.SetOrder(orderSO);
    }

    public void SubmitCurrentDish()
    {
        if(TryVerifyOrder())
        {
            //Gain cash

            //Empty plate

            //Discard current order

            //Empty plate
            mixingStation.EmptyPlate();
        }
    }

    private bool TryVerifyOrder()
    {
        return true;
    }
}
