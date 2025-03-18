using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private Canvas resultCanvas;
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
