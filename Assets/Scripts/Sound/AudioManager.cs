using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
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
        sfx_movement_track = gameObject.AddComponent<AudioSource>();
        sfx_damage_track = gameObject.AddComponent<AudioSource>();
        sfx_interactables_track = gameObject.AddComponent<AudioSource>();
        menus_track = gameObject.AddComponent<AudioSource>();
        bgm_track = gameObject.AddComponent<AudioSource>();
        bgm_track.loop = true;
    }



    public void Play(SoundType name, AudioSource track)
    {
        Sound sound = Array.Find(audioData.sounds, s => s.name == name);
        sound.source = track;
        sound.source.PlayOneShot(sound.clip);
    }
}