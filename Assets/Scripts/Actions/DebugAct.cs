using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Debug act", menuName = "ScriptableObjects/Acts/Debug")]
public class DebugAct : Act
{
    [SerializeField] string text;
    public override void DoAction()
    {
        Debug.Log(text);
    }
}
