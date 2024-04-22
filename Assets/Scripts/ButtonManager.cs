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

    public UnityEvent NewOrderButtonEvent;
    public UnityEvent DiscardButtonEvent;
    public UnityEvent SubmitButtonEvent;

    private void Awake()
    {
        newOrderButton.onClick.AddListener(() => {
            NewOrderButtonEvent.Invoke();
            //orderManager.AddNewOrder();
        });

        discardButton.onClick.AddListener(() => {
            DiscardButtonEvent.Invoke();
            //mixingStation.EmptyPlate();
        });

        submitButton.onClick.AddListener(() => {
            SubmitButtonEvent.Invoke();
            //SubmitCurrentDish();
        });
    }
}
