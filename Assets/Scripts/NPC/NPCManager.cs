using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(NPCStateMachine))]
public class NPCManager : MonoBehaviour
{
   private NPCStateMachine stateMachine;

    public NPCStateMachine StateMachine { get => stateMachine; }

    void Awake()
    {
        stateMachine = GetComponent<NPCStateMachine>();
    }

   
}
