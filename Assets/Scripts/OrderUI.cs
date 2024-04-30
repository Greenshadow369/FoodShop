using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private Button orderButton;
    [SerializeField] private Transform requirementPrefab;
    [SerializeField] private Transform requirementPos;
    [SerializeField] private Transform resultPos;
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

    public void CreateIngredientSprite(Sprite sprite)
    {
        Transform requirement = Instantiate(requirementPrefab, requirementPos);
        Image requirementImage = requirement.GetComponent<Image>();
        
        requirementImage.sprite = sprite;
    }

    public void CreateResultIngredientSprite(List<IngredientSO> resultList)
    {
        int z = 0;
        foreach(IngredientSO ingredientSO in resultList)
        {
            //Generate and set ingredient
            Transform requirement = Instantiate(requirementPrefab, resultPos);
            Image requirementImage = requirement.GetComponent<Image>();
            requirementImage.sprite = ingredientSO.GetIngredientSprite();

            //Sort sprite layer ordering
            z--;
            Canvas canva = requirement.GetComponent<Canvas>();
            canva.overrideSorting = true;
            canva.sortingOrder = z++;
        }
    }

    public void UpdateOrderSelectedVisual()
    {
        if(orderManager.GetSelectedOrder() == order)
        {
            orderSelectedVisual.gameObject.SetActive(true);
        }
        else
        {
            orderSelectedVisual.gameObject.SetActive(false);
        }
    }
}
