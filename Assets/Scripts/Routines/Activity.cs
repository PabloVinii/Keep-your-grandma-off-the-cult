using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Activity", menuName ="ScriptableObjects/Activity")]
public class Activity : ScriptableObject
{
    [SerializeField] private int hour , minute;
    [SerializeField] private string text;

    public int Hour { get => hour;}
    public int Minute { get => minute;}

    public void DoAction(){
        Debug.Log(text);
    }
}
