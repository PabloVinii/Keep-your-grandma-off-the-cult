using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : INPCState
{
    public void Enter(NPCStateMachine stateMachine)
    {

    }

    public void Update(NPCStateMachine stateMachine)
    {
         if (Vector2.Distance(stateMachine.transform.position, stateMachine.Target.position) > .5f)
        {
            stateMachine.ChangeState(stateMachine.WalkingState);
        }
    }
    public void Exit(NPCStateMachine stateMachine)
    {

    }


}
