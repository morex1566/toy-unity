using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class KeyMap
{
    // Movement
    static public KeyCode FrontWalk = KeyCode.W;
    static public KeyCode LeftWalk = KeyCode.A;
    static public KeyCode RightWalk = KeyCode.D;
    static public KeyCode BackWalk = KeyCode.S;

    static public KeyCode Run = KeyCode.LeftShift;
    static public KeyCode Roll = KeyCode.Space;


    // Interaction
    static public KeyCode Attack = KeyCode.Mouse0;
    static public KeyCode Block = KeyCode.Mouse1;
    static public KeyCode Ferry = Block;
    static public KeyCode Throw = KeyCode.F;

    static public KeyCode Primary1 = KeyCode.Alpha1;
    static public KeyCode Primary2 = KeyCode.Alpha2;
    static public KeyCode Secondary1 = KeyCode.Alpha3;
    static public KeyCode Secondary2 = KeyCode.Alpha4;

    static public KeyCode Drop = KeyCode.G;
    static public KeyCode Root = Drop;


    // UI
    static public KeyCode Setting = KeyCode.Escape;
    static public KeyCode ScoreBoard = KeyCode.Tab;


    static void ChangeKeyMap(ref KeyCode target_, ref KeyCode to_)
    {
        target_ = to_;
    }
}
