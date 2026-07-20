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

    public UnityEvent ResultMainMenuButtonEvent;
    public UnityEvent ResultReplayButtonEvent;

    private void Awake()
    {
        backButton.onClick.AddListener(() => {
            ResultMainMenuButtonEvent.Invoke();
        });

        //replayButton.onClick.AddListener(() => {
        //    ResultReplayButtonEvent.Invoke();
        //});
    }

    public void EnableUI()
    {
        //Enable canvas
        resultCanvas.enabled = true;
        //Animate UI
        windowRect.DOAnchorPosY(1500, 2).From().SetEase(Ease.InOutSine).SetUpdate(true);
        //Stop time scale
        Time.timeScale = 0;
        //Update text for UI
        UpdateText();
        //Reset order served value to 0
        orderServed.Variable.SetValue(0);
        //Mute SFX volume
        AudioManager.instance.MuteSFX();
    }

    public void DisableUI()
    {
        resultCanvas.enabled = false;
        //Resume time scale
        Time.timeScale = 1;
        //Unmute SFX volume
        AudioManager.instance.UnmuteSFX();
    }

    private void UpdateText()
    {
        timeText.text = "Level Time : " + levelTime.Value;
        orderText.text = "Order Served : " + orderServed.Value;
    }
}
