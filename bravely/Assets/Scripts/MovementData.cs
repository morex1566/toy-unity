using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MovementData", menuName = "Scriptable Object/MovementData", order = int.MaxValue)]
public class MovementData : ScriptableObject
{
    public float HP;
    public float SP;
    public float HPRegenerationSpeed;
    public float SPRegenerationSpeed;


    public float AttackSpeed;
    public float RotateSpeed;
    public float WalkSpeed;
    public float RunSpeed;


    public float AccelIdleToWalk;
    public float AccelWalkToRun;
    public float DecelWalkToIdle;
    public float DecelRunToWalk;


    public int STR;
    public int VIT;
    public int AGI;
    public int DEX;
}
