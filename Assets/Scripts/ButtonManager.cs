using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    //[SerializeField] private List<Button> ingredientButtonList;
    [SerializeField] private Button discardButton;
    [SerializeField] private Button newOrderButton;
    [SerializeField] private Button submitButton;

    public UnityEvent NewOrderRequested;
    public UnityEvent DiscardDishRequested;
    public UnityEvent SubmitOrderRequested;

    private void Awake()
    {
        newOrderButton.onClick.AddListener(() => {
            NewOrderRequested.Invoke();
            //orderManager.AddNewOrder();
        });

        discardButton.onClick.AddListener(() => {
            DiscardDishRequested.Invoke();
            //mixingStation.EmptyPlate();
        });

        submitButton.onClick.AddListener(() => {
            SubmitOrderRequested.Invoke();
            //SubmitCurrentDish();
        });
    }
}
