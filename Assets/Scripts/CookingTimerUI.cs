using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingTimerUI : MonoBehaviour
{
    [Header("World Clock")]
    [SerializeField] private Transform clockHand; // Assign the hand GameObject (with SpriteRenderer)
    [SerializeField] private Transform clockBackground; // Assign the background GameObject (with SpriteRenderer)


    [Header("Snap Settings")]
    [Tooltip("Interval in seconds between each 90-degree snap")]
    [SerializeField] private float interval = 1f; // Time in seconds between snaps
    private float accumulatedTime = 0f;
    private float currentAngle = 0f;

    void Update()
    {
        if (clockHand == null) return;

        accumulatedTime += Time.deltaTime;
        if (accumulatedTime >= interval)
        {
            accumulatedTime -= interval;
            currentAngle -= 90f;
            clockHand.localRotation = Quaternion.Euler(0f, 0f, currentAngle);
        }
    }

    public void SetClockVisible(bool visible)
    {
        gameObject.SetActive(visible);
    }
}
