using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DishStateSO", menuName = "Scriptable Object/DishStateSO")]
public class DishStateSO : ScriptableObject
{
    [NonSerialized] private State dishState;
    private enum State
    {
        Empty = 0,
        Started = 1,
        Finished = 2,
    }

    public void NextState()
    {
        switch(dishState)
        {
            case State.Empty:
                dishState = State.Started;
                break;
            case State.Started:
                dishState = State.Finished;
                break;
        }
    }

    private void OnEnable() {
        ResetDishState();
    }

    public bool IsDishEmpty()
    {
        return dishState == State.Empty;
    }

    public bool IsDishStarted()
    {
        return dishState == State.Started;
    }

    public bool IsDishFinished()
    {
        return dishState == State.Finished;
    }
    
    public String GetDishState()
    {
        return dishState.ToString();
    }

    public void ResetDishState()
    {
        dishState = State.Empty;
    }
}
