using System.Collections;
using System.Collections.Generic;
using LazySquirrelLabs.MinMaxRangeAttribute;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private IngredientListSO ingredientListSO;
    [SerializeField] private Transform orderPrefab;
    [SerializeField] private Transform orderGroup;

    [Header("For testing only")]
    [SerializeField] private DishStateSO dishStateSO;
    [SerializeField] private TextMeshProUGUI text;
    
    [Header("Fixed ingredients")]
    [SerializeField] private IngredientSO starterIngredient;
    [SerializeField] private IngredientSO finalizeIngredient;

    [Header("Statistics")]
    [SerializeField] FloatReference orderServed;

    [Header("Order Random Generator")]
    [SerializeField, MinMaxRange(1, 10)] private Vector2Int orderSpawnChance;
    [SerializeField, MinMaxRange(1f, 30f, 0)] private Vector2 timePerOpportunity;
    [Range(1, 9)]
    [SerializeField] private int numMaxOrder;

    [TextArea]
    public string Notes;


    private OrderSelectionSystem orderSelectionSystem;
    private List<Order> currentOrderList;
    private List<IngredientSO> availableIngredientSOList;
    private MixingStation mixingStation;
    private float timer;
    
    private float opportunityValue;

    private void Awake()
    {
        if(TryGetComponent<OrderSelectionSystem>(out OrderSelectionSystem orderSe))
        {
            orderSelectionSystem = orderSe;
        }

        if(GameObject.FindGameObjectWithTag("Mixing Station").TryGetComponent<MixingStation>(out MixingStation mixingStation_))
        {
            mixingStation = mixingStation_;
        }

        //Currently all ingredient in the ListSO is available in game
        availableIngredientSOList = new List<IngredientSO>(ingredientListSO.GetIngredientSOList());
    }

    private void Start()
    {
        currentOrderList = new List<Order>();
        //Generate a random time value for the first order
        opportunityValue = Random.Range(timePerOpportunity.x, timePerOpportunity.y);
    }

    private void Update()
    {
        text.text = dishStateSO.GetDishState();
        if(Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(orderServed.Value);
        }

        //Counting ime since last order
        timer += Time.deltaTime;
        
        if(timer >= opportunityValue)
        {
            timer = 0;
            //Generate a random time value for the next order
            opportunityValue = Random.Range(timePerOpportunity.x, timePerOpportunity.y);
            OrderRandomGenerator();
        }
    }
    
    public void AddNewOrder()
    {
        //Instantiate new prefab order
        Transform orderTransform = Instantiate(orderPrefab, orderGroup.position, Quaternion.identity, orderGroup);
        Order order = orderTransform.GetComponent<Order>();
        
        //OrderSO orderSO = possibleOrderList[Random.Range(0, possibleOrderList.Count)];
        List<IngredientSO> mainOrderRandomList = new List<IngredientSO>();

        //Starter: Adding required fixed starter ingredient
        mainOrderRandomList.Add(starterIngredient);

        //Filler: Random number of ingredients
        int ingredientNum = Random.Range(1, 4);
        
        for(int i = 0; i < ingredientNum; i++)
        {
            //Get a random ingredient
            IngredientSO randomIngre = availableIngredientSOList[Random.Range(0, availableIngredientSOList.Count)];
            //Add that random ingredient
            mainOrderRandomList.Add(randomIngre);
        }

        //Finalize: Adding required fixed finalize ingredient
        mainOrderRandomList.Add(finalizeIngredient);

        //Store the new order in a list
        currentOrderList.Add(order);

        //Pass and set new order info
        order.SetRequiredIngredientSO(mainOrderRandomList);

        // Play sound when adding orders
        AudioManager.instance.Play("OrderAdded");
    }

    public void SubmitCurrentDish()
    {
        if(TryVerifyOrder())
        {
            //Resolve order
            ResolveSubmittedOrder(GetSelectedOrder());

            // Play sound when selected
            AudioManager.instance.Play("SubmitDish");

            //Reset plate
            mixingStation.ResetDish();
        }
    }

    private bool TryVerifyOrder()
    {
        //Check if there is an order
        if(!IsThereOrder())
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
            Debug.Log(ingre.GetIngredientName());
        }

        //Get current selected order
        Order order = GetSelectedOrder();
        if(order == null)
        {
            //No order selected
            return false;
        }

        //Turn order into ingredientSO list
        List<IngredientSO> orderIngredientSOList = new List<IngredientSO>();
        foreach(IngredientSO ingreSO in order.GetMainDishIngredientList())
        {
            orderIngredientSOList.Add(ingreSO);
        }
        //dishIngredientSOList.Reverse();

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

    public void ResolveSubmittedOrder(Order order)
    {
        
        //Gain cash

        //Discard current order
        Order discardedOrder = order;
        currentOrderList.Remove(order);

        //Record
        orderServed.Variable.ApplyChange(1);

        Destroy(discardedOrder.gameObject);
    }

    public Order GetSelectedOrder()
    {
        return orderSelectionSystem.GetSelectedOrder();
    }

    public void SetSelectedOrder(Order order)
    {
        //Play sound when this order selected
        AudioManager.instance.Play("ClickOnTicket");

        orderSelectionSystem.SetSelectedOrder(order);
    }

    public Order GetFirstOrder()
    {
        return currentOrderList[0];
    }

    public bool IsThereOrder()
    {
        if(currentOrderList.Count > 0)
        {
            return true;
        }
        return false;
    }

    private void OrderRandomGenerator()
    {
        if(currentOrderList.Count >= numMaxOrder)
        {
            return;
        }

        int maxValue = 11;
        //Test difficulty
        int randomValue = Random.Range(1, maxValue);
        //Order spawn value
        int spawnValue = Random.Range(orderSpawnChance.x, orderSpawnChance.y);
        //If spawn value is higher or equal to test difficulty, then spawn order
        if(randomValue <= spawnValue)
        {
            AddNewOrder();
        }
    }
}
