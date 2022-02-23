using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data")]

public class PlayerData : ScriptableObject
{
    [Header("Jump State")]
    public float jumpVelocity = 5f;
    public SoundType jumpSFX;
    [Header("Climb State")]
    public float climbSpeed = 5f;
    public float ladderExitSpeed = 5f;
    [Header("Hitstun State")]
    public float defaultBounciness = 0f;
    public float hitstunBounciness = 1f;
    public float defaultFriction = 0f;
    public float hitstunFriction = 1f;

    [Header("Conjuration")]
    public Spell fireball;
    public Spell icecube;
    public Spell lightning;
    public float conjureRecoil = 5f;
    public float fireballSpeed = 5f;
    [Header("Timestop")]
    public float deltaTick = 30;
    public float timeStopScale = 0.01f;
    public float timestopKnockback = 10f;
    public SoundType clockSFX;
    [Header("Lightning")]
    public float lightningSpeed = 10f;

}
