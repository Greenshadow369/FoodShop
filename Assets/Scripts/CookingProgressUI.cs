using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingProgressUI : MonoBehaviour
{
    [SerializeField] private SpriteRenderer progressBarFilling;
    private float originalWidth;

    void Awake()
    {
        originalWidth = progressBarFilling.size.x;
    }

    public void SetProgress(float percent)
    {
        percent = Mathf.Clamp01(percent);

        float newWidth = originalWidth * percent;
        progressBarFilling.size = new Vector2(newWidth, progressBarFilling.size.y);

        progressBarFilling.transform.localPosition =
            new Vector3(-(originalWidth - newWidth) / 2f, 0, 0);
    }
}
