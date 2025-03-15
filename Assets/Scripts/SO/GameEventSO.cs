using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEventSO : ScriptableObject
{
    private readonly List<GameEventListener> eventListenerList = new List<GameEventListener>();

    public void Raise()
    {
        for(int i = eventListenerList.Count - 1; i >= 0; i--)
        {
            eventListenerList[i].OnEventRaised();
        }
    }

    public void RegisterListener(GameEventListener listener)
    {
        if(!eventListenerList.Contains(listener))
        {
            eventListenerList.Add(listener);
        }
    }

    public void UnregisterListener(GameEventListener listener)
    {
        if(eventListenerList.Contains(listener))
        {
            eventListenerList.Remove(listener);
        }
    }
}