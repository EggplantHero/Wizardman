using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioData audioData;

    [HideInInspector] public AudioSource bgm_track;
    [HideInInspector] public AudioSource sfx_track;

    void Awake()
    {
        sfx_track = gameObject.AddComponent<AudioSource>();
        bgm_track = gameObject.AddComponent<AudioSource>();
        bgm_track.loop = true;
    }

    void Start()
    {
        PlayMusic(SoundType.BGM_Wizardman);
    }



    public void Play(SoundType name)
    {
        Sound sound = Array.Find(audioData.sounds, s => s.name == name);
        sound.source = sfx_track;
        sound.source.PlayOneShot(sound.clip);
    }
    public void PlayMusic(SoundType name)
    {
        Sound sound = Array.Find(audioData.music, s => s.name == name);
        sound.source = bgm_track;
        sound.source.clip = sound.clip;
        sound.source.PlayDelayed(0);
    }
}