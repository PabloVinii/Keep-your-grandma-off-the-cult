using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DebugActivity", menuName = "ScriptableObjects/Activities/DebugActivity")]
public class DebugActivity : Activity
{
    [SerializeField] private string message;
    public override void DoAction()
    {
       Debug.Log("debugActivity: " + message);
    }

#region Equals and hashCode

    public override bool Equals(object obj)
    {
        return obj is DebugActivity activity &&
               base.Equals(obj) &&
               name == activity.name &&
               hideFlags == activity.hideFlags &&
               message == activity.message;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(base.GetHashCode(), name, hideFlags, message);
    }

#endregion

}
