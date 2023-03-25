using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class NPCStateMachine : MonoBehaviour
{
    private INPCState actualState;
    [SerializeField] private Transform target;
    [SerializeField] private float walkSpeed;
    private Rigidbody2D rig;

#region States
    private INPCState walkingState = new NPCWalkingState();
    private INPCState idleState = new NPCIdleState();
    public INPCState IdleState { get => idleState; }
    public INPCState WalkingState { get => walkingState; }
#endregion
    public Transform Target { get => target; }
    public float WalkSpeed { get => walkSpeed; }
    public Rigidbody2D Rig {get => rig;}

    private void Awake() {
        rig = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        ChangeState(walkingState);
    }

    void Update()
    {
        actualState?.Update(this);
    }

    public void ChangeState(INPCState state){
        this.actualState?.Exit(this);
        this.actualState = state;
        this.actualState?.Enter(this);
    }
}
