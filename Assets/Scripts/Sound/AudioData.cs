using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(fileName = "newAudioData", menuName = "Data/Audio Data")]
public class AudioData : ScriptableObject
{
    public Sound[] sounds;
    public Sound[] music;
}

[System.Serializable]
public class Sound
{
    public SoundType name;
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 1f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}

public enum SoundType
{
    SFX_None,
    SFX_Jump,
    SFX_Bounce,
    SFX_TakeDamage,
    SFX_FireballExplosion,
    SFX_FireballCast,
    SFX_HealthPotion,
    SFX_ManaPotion,
    SFX_Ticktock,
    SFX_LightningCast,
    SFX_LightningBoom,
    SFX_LightningHit,
    SFX_IceCast,
    SFX_IceCollision,
    SFX_PlayerLanding,
    BGM_Wizardman,
    BGM_Lizardman,
    BGM_Battle,
}

public enum AudioTrack
{
    SFX_Movement,
    SFX_Damage,
    SFX_Interactables,
    BGM,
    MENUS,
}
