using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoveActivity", menuName = "ScriptableObjects/Activities/MoveActivity")]
public class MoveActivity : Activity
{
    [SerializeField] Vector2 target;
    public override void DoAction(NPCManager manager)
    {
       manager.StateMachine.Target = target;
       manager.StateMachine.ChangeState(manager.StateMachine.WalkingState);
    }
#region Equals and hashCode

    public override bool Equals(object obj)
    {
        return obj is MoveActivity activity &&
               base.Equals(obj) &&
               name == activity.name &&
               hideFlags == activity.hideFlags &&
               EqualityComparer<Vector2>.Default.Equals(target, activity.target);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), name, hideFlags, target);
    }

#endregion
}
