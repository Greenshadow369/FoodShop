using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    [Header("Order Ticket")]
    [SerializeField] private Button orderButton;
    [SerializeField] private Transform orderTicketHoveredVisual;
    [SerializeField] private Transform orderSelectedVisual;

    [Header("Order Ticket Contents")]
    [SerializeField] private Transform requirementPrefab;
    [SerializeField] private Transform requirementPos;
    [SerializeField] private Transform resultPos;

    private OrderManager orderManager;
    private Order order;

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

    public void CreateRequirementSprite(List<IngredientSO> requirementList)
    {
        CreateRequirementSpriteHelper(requirementList);
    }

    private void CreateRequirementSpriteHelper(List<IngredientSO> requirementList)
    {
        int z = 0;
        foreach(IngredientSO ingredientSO in requirementList)
        {
            //Generate and set ingredient
            Transform requirement = Instantiate(requirementPrefab, requirementPos);
            Image requirementImage = requirement.GetComponent<Image>();
            requirementImage.sprite = ingredientSO.GetIngredientSprite();

            //Sort sprite layer ordering
            Canvas requirementCanvas = requirement.GetComponent<Canvas>();
            requirementCanvas.overrideSorting = true;
            requirementCanvas.sortingOrder = z++;
        }
    }

    public void CreateResultSprite(List<IngredientSO> resultList)
    {
        //Bottom ingredients
        //CreateResultSpriteHelper(order.GetDefaultIngredientBottomList());

        //Middle ingredients
        CreateResultSpriteHelper(resultList);

        //Top ingredients
        //CreateResultSpriteHelper(order.GetDefaultIngredientTopList());
    }

    private void CreateResultSpriteHelper(List<IngredientSO> ingreList)
    {
        int z = 0;
        foreach(IngredientSO ingredientSO in ingreList)
        {
            //Generate and set ingredient
            Transform result = Instantiate(requirementPrefab, resultPos);
            Image resultImage = result.GetComponent<Image>();
            resultImage.sprite = ingredientSO.GetIngredientSprite();

            //Sort sprite layer ordering
            Canvas resultCanvas = result.GetComponent<Canvas>();
            resultCanvas.overrideSorting = true;
            resultCanvas.sortingOrder = z++;
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

    public void TicketHoveredVisualOn()
    {
        orderTicketHoveredVisual.gameObject.SetActive(true);
    }

    public void TicketHoveredVisualOff()
    {
        orderTicketHoveredVisual.gameObject.SetActive(false);
    }
}
