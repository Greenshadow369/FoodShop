using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WipeToBlackTransition : MonoBehaviour
{
    private bool fadeToBlackFinished = false;
    public void OnFadeToBlackFinished()
    {
        fadeToBlackFinished = true;
    }

    public void ResetFadeToBlackFinished()
    {
        fadeToBlackFinished = false;
    }

    public bool IsFadeToBlackFinished()
    {
        return fadeToBlackFinished;
    }
}
