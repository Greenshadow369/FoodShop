using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
    private Tween gameMenuTween;
    private CanvasGroup gameMenuCanvasGroup;
    private CanvasGroup modeMenuCanvasGroup;

    private void Awake()
    {
        modeMenuCanvasGroup = modeMenu.GetComponent<CanvasGroup>();
        if (modeMenuCanvasGroup == null)
        {
            // safety: auto add one if forgot to add one in the inspector
            modeMenuCanvasGroup = modeMenu.AddComponent<CanvasGroup>();
        }

        gameMenuCanvasGroup = gameMenu.GetComponent<CanvasGroup>();
        if (gameMenuCanvasGroup == null)
        {
            // safety: auto add one if forgot to add one in the inspector
            gameMenuCanvasGroup = gameMenu.AddComponent<CanvasGroup>();
        }

        //Set up animation for reuse
        gameMenuTween = gameMenu.GetComponent<RectTransform>().DOAnchorPosX(2000, 1)
                                 .From()
                                 .SetEase(Ease.OutQuad)
                                 .SetAutoKill(false)
                                 .Pause();
        gameMenuTween.Restart();

        gameMenuTween.OnPlay(() =>
            {
                gameMenuCanvasGroup.blocksRaycasts = false;
            }
        );

        gameMenuTween.OnRewind(() =>
            {
                gameMenu.SetActive(false);
                gameMenuCanvasGroup.blocksRaycasts = true;
            }
        );
            
        gameMenuTween.OnComplete(()=>
            {
                gameMenuCanvasGroup.blocksRaycasts = true;
            }
        );
    }

    private void ChangeGameMenuActiveState(GameObject target)
    {
        if (target.activeSelf)
        {
            //Animate game menu transition out
            //target.GetComponent<RectTransform>().DOAnchorPosX(-2000, 1).From().SetEase(Ease.OutQuad).OnComplete(()
            //    => target.SetActive(false));

            gameMenuTween.PlayBackwards();

        }
        else
        {

            target.SetActive(true);
            gameMenuTween.Restart();
            
            //Animate game menu transition in
            //target.GetComponent<RectTransform>().DOAnchorPosX(2000, 1).From().SetEase(Ease.OutQuad);
        }
    }

    private void ChangeModeMenuActiveState(GameObject target)
    {
        if (target.activeSelf)
        {
            //Animate game menu transition out
            //target.GetComponent<RectTransform>().DOAnchorPosX(-2000, 1).From().SetEase(Ease.OutQuad).OnComplete(()
            //    => target.SetActive(false));
            target.SetActive(false);

        }
        else
        {
            target.SetActive(true);
            //Animate mode menu transition in
            //target.GetComponent<RectTransform>().DOAnchorPosX(-2000, 1).From().SetEase(Ease.OutQuad);
        }
    }

    public void ChangeGameMenuActiveState()
    {
        ChangeGameMenuActiveState(gameMenu);
    }

    public void ChangeModeMenuActiveState()
    {
        ChangeModeMenuActiveState(modeMenu);
    }
}
