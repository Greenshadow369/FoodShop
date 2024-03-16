using System.Collections;
using System.Collections.Generic;
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
            //Empty plate
            mixingStation.EmptyPlate();
        }
    }

    private bool TryVerifyOrder()
    {
        return true;
    }
}
