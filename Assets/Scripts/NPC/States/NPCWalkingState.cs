using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCWalkingState : INPCState
{
    private Pahtfinding pathfinding;
    private List<Node> path;

    private Vector2 actualTarget;
    private int pathIndex;
    public void Enter(NPCStateMachine stateMachine)
    {
        pathIndex = 0;
        if (pathfinding == null) pathfinding = new Pahtfinding();
        path = pathfinding.FindPath(stateMachine.transform.position, stateMachine.Target);
        actualTarget = path[0].worldPosition;

    }

    public void Update(NPCStateMachine stateMachine)
    {
        if (Vector2.Distance(stateMachine.transform.position, actualTarget) < .1f)
        {
            pathIndex++;

            if (pathIndex >= path.Count)
            {
                stateMachine.ChangeState(stateMachine.IdleState);
            }else{
                actualTarget = path[pathIndex].worldPosition;
            }

        }


        Vector3 direction = actualTarget - (Vector2)stateMachine.transform.position;

        stateMachine.transform.position += direction.normalized * stateMachine.WalkSpeed * Time.deltaTime;


    }
    public void Exit(NPCStateMachine stateMachine)
    {
        stateMachine.Rig.velocity = new Vector2(0f, 0f);
        path.Clear();
    }

}
