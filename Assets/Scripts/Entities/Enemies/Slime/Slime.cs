using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : Enemy

{
    public SoundType stompSFX;
    public HitstunState HitstunState { get; private set; }
    public MoveXState MoveXState { get; private set; }

    public override void Awake()
    {
        base.Awake();
        MoveXState = new MoveXState(this, "Idling");
        HitstunState = new HitstunState(this, "Damaged");
    }

    public void Start()
    {
        stateMachine.Initialize(MoveXState);
    }

    public override void Update()
    {
        if (combat.Hitstun)
        {
            stateMachine.SetState(HitstunState);
        }
        else
        {
            stateMachine.SetState(MoveXState);
        }
        base.Update();
    }

    public override void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.name == "Feet")
        {
            audioManager.Play(stompSFX, audioManager.sfx_damage_track);
            combat.Die();
        }
        else
        {
            base.OnCollisionEnter2D(col);
        }
    }

}
