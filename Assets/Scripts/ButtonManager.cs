using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //[SerializeField] private List<Button> ingredientButtonList;
    [SerializeField] private Button discardButton;
    [SerializeField] private Button orderButton;
    [SerializeField] private Button submitButton;

    private MixingStation mixingStation;
    private OrderManager orderManager;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Mixing Station").TryGetComponent<MixingStation>(out MixingStation mixingStation_))
        {
            mixingStation = mixingStation_;
        }

        if(GameObject.FindGameObjectWithTag("Order Manager").TryGetComponent<OrderManager>(out OrderManager orderManager_))
        {
            orderManager = orderManager_;
        }

        orderButton.onClick.AddListener(() => {
            orderManager.AddNewOrder();
        });

        discardButton.onClick.AddListener(() => {
            mixingStation.EmptyPlate();
        });

        submitButton.onClick.AddListener(() => {
            SubmitCurrentDish();
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SubmitCurrentDish()
    {
        if(TryVerifyOrder())
        {
            //Resolve order
            orderManager.ResolveSubmittedOrder();

            //Empty plate
            mixingStation.EmptyPlate();
        }
    }

    private bool TryVerifyOrder()
    {
        //Check if there is an order
        if(!orderManager.IsThereOrder())
        {
            return false;
        }

        //Get current dish
        List<Ingredient> dishIngredientList = new List<Ingredient>(mixingStation.GetDish());
        //Turn dish into ingredientSO list
        List<IngredientSO> dishIngredientSOList = new List<IngredientSO>();
        foreach(Ingredient ingre in dishIngredientList)
        {
            dishIngredientSOList.Add(ingre.GetIngredientSO());
        }

        //Get current selected order
        //Order order = orderManager.GetSelectedOrder();
        Order order = orderManager.GetFirstOrder();
        OrderSO orderSO = order.GetOrderSO();   //OrderSO orderSO = Instantiate<OrderSO>(orderManager.GetFirstOrderSO());
        
        //Turn order into ingredientSO list
        List<IngredientSO> orderIngredientSOList = new List<IngredientSO>();
        foreach(IngredientSO ingreSO in orderSO.GetOrderIngredientList())
        {
            orderIngredientSOList.Add(ingreSO);
        }
        dishIngredientSOList.Reverse();

        //Compare order and dish size
        if(dishIngredientSOList.Count != orderIngredientSOList.Count)
        {
            return false;
        }
        
        //Compare order and dish ingredients
        for(int i = 0; i < orderIngredientSOList.Count; i++)
        {
            if(orderIngredientSOList[i].GetIngredientName() != dishIngredientSOList[i].GetIngredientName())
            {
                return false;
            }
        }
        
        //Submitted dish is good
        return true;
    }
}
