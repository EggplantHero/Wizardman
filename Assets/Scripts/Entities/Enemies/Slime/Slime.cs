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

}
