using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : Entity
{
    #region State Machine
    public PlayerOpenState OpenState { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerRunState RunState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAerialState AerialState { get; private set; }
    public PlayerClimbState ClimbState { get; private set; }
    public PlayerCastState CastState { get; private set; }
    public PlayerFireballState FireballState { get; private set; }
    public PlayerFrostState FrostState { get; private set; }
    public PlayerLightningState LightningState { get; private set; }
    public PlayerGravityState GravityState { get; private set; }
    public PlayerTimestopState TimestopState { get; private set; }
    public PlayerDamageState DamageState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    #endregion

    #region Data
    public InventoryObject inventory;
    public PlayerData playerData;
    [HideInInspector]
    public bool castAvailable;
    #endregion


    public override void Awake()
    {
        base.Awake();
        OpenState = new PlayerOpenState(this, "Idling");
        IdleState = new PlayerIdleState(this, "Idling");
        RunState = new PlayerRunState(this, "Running");
        JumpState = new PlayerJumpState(this, "Idling");
        AerialState = new PlayerAerialState(this, "Idling");
        ClimbState = new PlayerClimbState(this, "Climbing");
        CastState = new PlayerCastState(this, "Idling");
        FireballState = new PlayerFireballState(this, "Casting");
        FrostState = new PlayerFrostState(this, "Casting");
        LightningState = new PlayerLightningState(this, "Lightning");
        GravityState = new PlayerGravityState(this, "Casting");
        TimestopState = new PlayerTimestopState(this, "Casting");
        DamageState = new PlayerDamageState(this, "Damaged");
        DeadState = new PlayerDeadState(this, "Dead");
    }

    private void Start()
    {
        stateMachine.Initialize(OpenState);
        castAvailable = true;
        Singleton.Main.UIManager.Health.Initialize(combat.MaxHealth);
    }

    public override void Update()
    {
        base.Update();
    }

    private void OnApplicationQuit()
    {
        inventory.Clear();
    }

}
