using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weapon : MonoBehaviour
{
    private float comboInterval;
    private float delay;
    private Collider attackRange;

    // Attack method
    abstract public void LeftAttack();
    abstract public void RightAttack();
    abstract public void UpAttack();

    // Block method
    abstract public void LeftBlock();
    abstract public void RightBlock();
    abstract public void UpBlock();
}
