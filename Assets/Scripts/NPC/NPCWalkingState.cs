using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkingState : INPCState
{
    public void Enter(NPCStateMachine stateMachine)
    {

    }

    public void Update(NPCStateMachine stateMachine)
    {
        if (Vector2.Distance(stateMachine.transform.position, stateMachine.Target.position) < .5f)
        {
            stateMachine.ChangeState(stateMachine.IdleState);
        }


        Vector2 direction =  stateMachine.Target.position - stateMachine.transform.position;

        stateMachine.Rig.velocity += direction.normalized * stateMachine.WalkSpeed * Time.deltaTime;


    }
    public void Exit(NPCStateMachine stateMachine)
    {
        stateMachine.Rig.velocity = new Vector2(0f,0f);
    }

}
