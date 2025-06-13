using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance { get; private set; }

    [SerializeField] float sceneLoadDelay = 2f;
    [SerializeField] float sceneTransitionDelay = 2f;
    [SerializeField] Animator sceneTransition;

    public UnityEvent OnTimedGameLoaded;
    public UnityEvent OnRelaxedGameLoaded;
    private AudioManager audioManager;
    private bool isRelaxedModeNext;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("There are more than one LevelManager! " + transform + " - " + instance);
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void LoadGame()
    {
        StartCoroutine(WaitAndLoad("Game", false, sceneLoadDelay));
    }

    public void LoadTimedGame()
    {
        isRelaxedModeNext = false;
        LoadGame();
    }

    public void LoadRelaxedGame()
    {
        isRelaxedModeNext = true;
        LoadGame();
    }

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad("MainMenu", false, sceneLoadDelay));
    }

    /* public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad("GameOver", true, sceneLoadDelay, 
            audioManager.PlayGameOverClip));
    }

    public void LoadShop()
    {
        StartCoroutine(WaitAndLoad("Shop", true, sceneLoadDelay, 
            audioManager.PlayShopClip));
    } */

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, bool isTransitionDelayed, float delay)
    {
         if(isTransitionDelayed)
        {
            yield return new WaitForSeconds(sceneTransitionDelay);
        }

        sceneTransition.SetTrigger("StartTransition");

        yield return new WaitForSeconds(delay);

        /*This solution is found online, which add an event handler that 
        run after scene fully loaded (including objects)*/
        var op = SceneManager.LoadSceneAsync(sceneName);
        op.completed += (x) => {
            if(sceneName == "Game")
            {
                if(isRelaxedModeNext)
                {
                    OnRelaxedGameLoaded.Invoke();
                }
                else
                {
                    OnTimedGameLoaded.Invoke();
                }
            }
        };
    }

    IEnumerator WaitAndLoad(string sceneName, bool isTransitionDelayed, float delay, Action changeMusicClip)
    {
         if(isTransitionDelayed)
        {
            yield return new WaitForSeconds(sceneTransitionDelay);
        }

        sceneTransition.SetTrigger("StartTransition");

        yield return new WaitForSeconds(delay);

        /*This solution is found online, which add an event handler that 
        run after scene fully loaded (including objects)*/
        var op = SceneManager.LoadSceneAsync(sceneName);
        op.completed += (x) => {
            if(sceneName == "Game")
            {
                //cardManager.UseCards();
            }
        };
        
        changeMusicClip();
    }
}
