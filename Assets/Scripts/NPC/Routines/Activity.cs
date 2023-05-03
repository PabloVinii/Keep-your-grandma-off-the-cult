using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Activity : ScriptableObject
{
    public abstract void DoAction(NPCManager manager);
 }
