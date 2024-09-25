using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    private void Start()
    {
        foreach(Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.name = s.name;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string name)
    {
        foreach(Sounds s in sounds)
        {
            if (s.name == name)
            {
                s.source.Play();
            }
        }
    }
}
