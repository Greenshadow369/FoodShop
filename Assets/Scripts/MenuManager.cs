using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    /*
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button timedButton;
    [SerializeField] private Button relaxButton;
    (save in case of moving button events from the button itself to here) */

    [SerializeField] GameObject gameMenu;
    [SerializeField] GameObject modeMenu;

    private void ChangeActiveState(GameObject gameObject)
    {
        if(gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void ChangeGameMenuActiveState()
    {
        ChangeActiveState(gameMenu);
    }

    public void ChangeModeMenuActiveState()
    {
        ChangeActiveState(modeMenu);
    }
}
