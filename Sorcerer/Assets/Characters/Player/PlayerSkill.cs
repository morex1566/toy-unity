using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private Skill[] skillSlot;

    PlayerSkill()
    {
        
    }

    ~PlayerSkill()
    {

    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        use();
    }

    private void use()
    {

    }
}

internal abstract class Skill
{
    public abstract void work();
}