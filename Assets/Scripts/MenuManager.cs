using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button timedButton;
    [SerializeField] private Button relaxButton;
    
    public void Activate()
    {
        gameObject.SetActive(true);
    }
}
