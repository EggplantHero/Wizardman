using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioData audioData;
    [HideInInspector]
    public AudioSource bgm_track;
    [HideInInspector]
    public AudioSource sfx_movement_track;
    [HideInInspector]
    public AudioSource sfx_damage_track;
    [HideInInspector]
    public AudioSource sfx_interactables_track;
    [HideInInspector]
    public AudioSource menus_track;

    void Awake()
    {
        if (instance) Destroy(this.gameObject); else instance = this;
        sfx_movement_track = gameObject.AddComponent<AudioSource>();
        sfx_damage_track = gameObject.AddComponent<AudioSource>();
        sfx_interactables_track = gameObject.AddComponent<AudioSource>();
        menus_track = gameObject.AddComponent<AudioSource>();
        bgm_track = gameObject.AddComponent<AudioSource>();
        bgm_track.loop = true;
    }

    void Start()
    {
        PlayMusic(SoundType.BGM_Wizardman, bgm_track);
    }



    public void Play(SoundType name, AudioSource track)
    {
        Sound sound = Array.Find(audioData.sounds, s => s.name == name);
        sound.source = track;
        sound.source.PlayOneShot(sound.clip);
    }
    public void PlayMusic(SoundType name, AudioSource track)
    {
        Sound sound = Array.Find(audioData.music, s => s.name == name);
        sound.source = track;
        sound.source.clip = sound.clip;
        sound.source.PlayDelayed(0);
    }
}