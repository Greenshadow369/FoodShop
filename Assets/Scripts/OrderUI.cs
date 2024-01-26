using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private Image order;
    [SerializeField] private Transform requirementPrefab;
    [SerializeField] private Transform requirementPos;
    //[SerializeField] private Image ingredient;

    public void SetOrderSprite(Sprite sprite)
    {
        order.sprite = sprite;
    }

    public void CreateIngredientSprite(Sprite sprite)
    {
        Transform requirement = Instantiate(requirementPrefab, requirementPos);
        Image requirementImage = requirement.GetComponent<Image>();
        
        requirementImage.sprite = sprite;
    }
}
