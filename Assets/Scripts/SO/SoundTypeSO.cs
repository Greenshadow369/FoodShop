using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Scriptable Object/SoundTypeSO")]
//This is a scriptable object for defining different types of sounds in the game
public class SoundTypeSO : ScriptableObject
{
    public AudioMixerGroup mixerGroup;

    //Properties for each specific sound type such as pause during pause menu, ... are added here
}