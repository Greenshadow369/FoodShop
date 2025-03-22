using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class ResultUI : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private Canvas resultCanvas;

    [Header("Window")]
    [SerializeField] private RectTransform windowRect;

    [Header("Button")]
    [SerializeField] private Button backButton;
    [SerializeField] private Button replayButton;
    
    [Header("Text")]
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private FloatReference orderServed;
    [SerializeField] private FloatReference levelTime;

    public UnityEvent ResultBackButtonEvent;
    public UnityEvent ResultReplayButtonEvent;

    private void Awake()
    {
        backButton.onClick.AddListener(() => {
            ResultBackButtonEvent.Invoke();
        });

        replayButton.onClick.AddListener(() => {
            ResultReplayButtonEvent.Invoke();
        });
    }

    public void EnableUI()
    {
        resultCanvas.enabled = true;
        //Animate UI
        windowRect.DOAnchorPosY(1500, 3).From().SetEase(Ease.InOutSine);
        //Update text for UI
        UpdateText();
        //Reset order served value to 0
        orderServed.Variable.SetValue(0);
    }

    public void DisableUI()
    {
        resultCanvas.enabled = false;
    }

    private void UpdateText()
    {
        timeText.text = "Level Time : " + levelTime.Value;
        orderText.text = "Order Served : " + orderServed.Value;
    }
}
