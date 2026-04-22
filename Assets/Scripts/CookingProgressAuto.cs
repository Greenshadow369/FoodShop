using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingProgressAuto : MonoBehaviour
{
    [SerializeField] private CookingProgressUI cookingProgressUI;
    private float cookTime = 5f; // Total cooking time in seconds
    private float elapsedTime = 0f; // Time elapsed since cooking started
    private bool isCooking = false;

    void Update()
    {
        if (!isCooking)
        {
            return; // Do nothing if not cooking
        }
        elapsedTime += Time.deltaTime;
        float progress = elapsedTime / cookTime;
        cookingProgressUI.SetProgress(progress);
        if (elapsedTime >= cookTime)
        {
            // Cooking is complete, you can add any additional logic here
            Debug.Log("Cooking complete!");
            isCooking = false; // Stop cooking
        }
    }

    public void StartCooking(float newCookTime)
    {
        cookTime = newCookTime;
        elapsedTime = 0f;
        isCooking = true;
    }
}
