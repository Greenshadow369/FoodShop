using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

//Serialize any menu panel
[System.Serializable]
public class MenuPanel
{
    public GameObject panel;
    [HideInInspector] public CanvasGroup canvasGroup;
    [HideInInspector] public Tween tween;
}

public class MenuManager : MonoBehaviour
{
    /*
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    [SerializeField] private Button timedButton;
    [SerializeField] private Button relaxButton;
    (save in case of moving button events from the button itself to here) */

    [SerializeField] private MenuPanel gameMenu;
    [SerializeField] private MenuPanel modeMenu;

    private void Awake()
    {
        //Setup menus (active state, animation)
        InitMenu(gameMenu, 2000, true);
        InitMenu(modeMenu, -2000, false);
    }

    private void InitMenu(MenuPanel menu, float fromX, bool startActive)
    {
        // Ensure CanvasGroup
        menu.canvasGroup = menu.panel.GetComponent<CanvasGroup>();
        if (menu.canvasGroup == null)
            menu.canvasGroup = menu.panel.AddComponent<CanvasGroup>();

        // Determine if needing to temporarily activate the panel for tween initialization
        bool needsTemporaryActivation = !menu.panel.activeSelf || !startActive;
        if (needsTemporaryActivation)
            menu.panel.SetActive(true);

        // Create tween once (paused, reusable)
        RectTransform rt = menu.panel.GetComponent<RectTransform>();
        menu.tween = rt.DOAnchorPosX(fromX, 1)
                    .From()
                    .SetEase(Ease.OutQuad)
                    .SetAutoKill(false)
                    .Pause();

        //Disable interaction during animation
        menu.tween.OnPlay(() => menu.canvasGroup.blocksRaycasts = false);

        //Disable interaction during rewind animation
        menu.tween.OnRewind(() =>
        {
            menu.panel.SetActive(false);
            menu.canvasGroup.blocksRaycasts = false;
        });

        //Enable interaction after animation
        menu.tween.OnComplete(() => menu.canvasGroup.blocksRaycasts = true);

        // Play initial animation only if menu should start active
        if (startActive)
        {
            menu.tween.Restart();
        }

        // Restore panel to inactive if it should start inactive
        if (!startActive)
        {
            menu.panel.SetActive(false);
            menu.canvasGroup.blocksRaycasts = false;
        }
    }

    private void ToggleMenu(MenuPanel menu)
    {
        if (menu.panel.activeSelf)
        {
            // Animate out
            menu.tween.PlayBackwards();
        }
        else
        {
            // Animate in
            menu.panel.SetActive(true);
            menu.tween.Restart();
        }
    }

    // Public buttons call these:
    public void ToggleGameMenu()
    { 
        ToggleMenu(gameMenu);
    }
    public void ToggleModeMenu()
    {
        ToggleMenu(modeMenu);
    }
}
