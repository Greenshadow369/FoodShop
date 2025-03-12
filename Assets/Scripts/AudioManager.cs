using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set;}
    
    public Sound[] sounds;

    void Awake()
    {
        // Make sure there is only one instance of the audio playing
        // If not, remove it
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("There are more than one AudioManager! " + transform + " - " + instance);
            Destroy(gameObject);
            // This is to make sure no more code is called before
            // the object is destroyed
            return;
        }


        // Don't stop the music after changing scenes
        DontDestroyOnLoad(gameObject);


        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;


            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }


    void Start ()
    {
        Play("MainTheme");
    }


    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.soundName == name);

        // Check if the sound file is correct
        // if not, don't play the sound and return
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!!!!");
            return;
        }
        s.source.Play();
    }

}
