using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sound;

    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sounds s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.Name == name);
        s.source.Play();
    }
    public void Stop(string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.Name == name);
        s.source.Stop();
    }
}
