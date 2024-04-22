using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private Image orderResultImage;
    [SerializeField] private Button orderButton;
    [SerializeField] private Transform requirementPrefab;
    [SerializeField] private Transform requirementPos;
    [SerializeField] private Transform orderSelectedVisual;

    private OrderManager orderManager;
    private Order order;
    //[SerializeField] private Image ingredient;

    private void Awake()
    {
        if(GameObject.FindGameObjectWithTag("Order Manager").TryGetComponent<OrderManager>(out OrderManager orderManager_))
        {
            orderManager = orderManager_;
        }

        order = GetComponent<Order>();
    }

    private void Start()
    {
        orderButton.onClick.AddListener(() => {
            orderManager.SetSelectedOrder(order);
        });
    }

    public void SetOrderSprite(Sprite sprite)
    {
        orderResultImage.sprite = sprite;
    }

    public void CreateIngredientSprite(Sprite sprite)
    {
        Transform requirement = Instantiate(requirementPrefab, requirementPos);
        Image requirementImage = requirement.GetComponent<Image>();
        
        requirementImage.sprite = sprite;
    }
}
