using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Action
{
    static public Roll roll = null;
    static public Idle idle = null;
    static public LeftAttack leftAttack = null;
    static public RightAttack rightAttack = null;
    static public HeavyLeftAttack heavyLeftAttack = null;
    static public HeavyRightAttack HeavyRightAttack = null;
    static public Block block = null;
    static public Ferry ferry = null;

    protected int comboCount = 0;

    // Pls call at once!
    static public void CreateAction(CharacterRoot root_)
    {
        if (roll == null) { roll = new Roll(ref root_); }
        if (idle == null) { idle = new Idle(ref root_); }
        if (leftAttack == null) { leftAttack = new LeftAttack(ref root_); }
        if (rightAttack == null) { rightAttack = new RightAttack(ref root_); }
        if (heavyLeftAttack == null) { heavyLeftAttack= new HeavyLeftAttack(ref root_); }    
        if (HeavyRightAttack == null) { HeavyRightAttack = new HeavyRightAttack(ref root_); }    
        if (block == null) { block = new Block(ref root_); }
        if (ferry == null) { ferry = new Ferry(ref root_); }
    }

    [SerializeReference] protected CharacterRoot root;
    [SerializeReference] protected CharacterInteractionEvent eventHandler;

    protected bool isActive;
    public bool IsActive { get { return isActive; } set { isActive = value; } }

    abstract public void HandleInput();
    abstract public void InnerUpdate();
    abstract public void OnEventStart();
    abstract public void OnEventEnd();

    abstract protected void move();

}
