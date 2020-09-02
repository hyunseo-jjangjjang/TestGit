using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    buttonClick,
    Win,
    Lose,
}
[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource audio;

    public List<AudioClip> sounds;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        audio = GetComponent<AudioSource>();
    }

    public void PlaySound(Sounds sound)
    {
        audio.PlayOneShot(sounds[(int)sound]);
    }
}
