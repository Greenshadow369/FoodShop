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
    [SerializeField] private DishStateSO dishStateSO;
    [SerializeField] private WipeToBlackTransition wipeToBlackTransition;

    public UnityEvent NewTimedGameStarted;
    public UnityEvent NewRelaxedGameStarted;
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
        if (dishStateSO == null)
        {
            Debug.LogWarning("DishStateSO is not assigned in LevelManager. The dish state will not be reset.");
        }
        else
        {
            dishStateSO.ResetDishState();
        }

        Time.timeScale = 1f;
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
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoad("MainMenu", false, sceneLoadDelay));
    }

    public void LoadPreparation()
    {
        Time.timeScale = 1f;
        StartCoroutine(WaitAndLoad("Preparation", false, sceneLoadDelay));
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

    IEnumerator WaitAndLoad(string sceneName, bool isTransitionDelayed, float delay, Action changeMusicClip = null)
    {
        if(isTransitionDelayed)
        {
            yield return new WaitForSecondsRealtime(sceneTransitionDelay);
        }

        // Reset the signal before starting the fade
        wipeToBlackTransition.ResetFadeToBlackFinished();

        // Start the fade-to-black animation
        sceneTransition.SetTrigger("StartTransition");

        // Wait until the animation event signals completion
        yield return new WaitUntil(() => wipeToBlackTransition.IsFadeToBlackFinished());

        // Stay on the screen black for the requested duration
        yield return new WaitForSecondsRealtime(delay);

        //Now the screen is just a static black, we can load the next scene without worrying about the transition animation being interrupted
        //The next scene will be loaded and the transition animation will play again in that scene
        //Load the scene asynchronously
        var op = SceneManager.LoadSceneAsync(sceneName);
        // Wait until the scene is fully loaded
        yield return op;

        //Game scene is loaded, now we can invoke the event to notify that a new game has started
        if(sceneName == "Game")
        {
            if(isRelaxedModeNext)
            {
                NewRelaxedGameStarted.Invoke();
            }
            else
            {
                NewTimedGameStarted.Invoke();
            }
        }

        if(changeMusicClip != null)
        {
            changeMusicClip();
        }
    }
}
