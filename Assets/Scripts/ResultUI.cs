using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultUI : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private Canvas resultCanvas;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            DisableUI();
        }
    }

    public void EnableUI()
    {
        resultCanvas.enabled = true;
    }

    public void DisableUI()
    {
        resultCanvas.enabled = false;
    }
}
