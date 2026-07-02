using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Currently unused, better use on click in inspector, or a dedicated script for specific button behavior
public class ButtonClicked : MonoBehaviour
{
    [SerializeField] private Button button;
    public UnityEvent ButtonEvent;

    private void Awake()
    {
        button.onClick.AddListener(() => {
            ButtonEvent.Invoke();
        });
    }

}
