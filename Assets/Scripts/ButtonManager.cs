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
    [SerializeField] private Button orderButton;
    [SerializeField] private Button submitButton;

    public UnityEvent OrderButtonEvent;
    public UnityEvent DiscardButtonEvent;
    public UnityEvent SubmitButtonEvent;

    private void Awake()
    {
        orderButton.onClick.AddListener(() => {
            OrderButtonEvent.Invoke();
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
