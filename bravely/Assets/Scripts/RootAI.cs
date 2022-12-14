using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class RootAI : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AnimatorController defaultController;
    [SerializeField] private Rigidbody rigid;
    [SerializeField] private MovementData movementData;


    private CharacterState state;
    private Movement movement;
    private Action action;
    private Equipment equipment;


    // Property
    public Animator Animator { get { return animator; } set { animator = value; } }
    public Rigidbody Rigid { get { return rigid; } set { rigid = value; } }
    public MovementData MovementData { get { return movementData; } set { movementData = value; } }
    public CharacterState State { get { return state; } }
    public Movement Movement { get { return movement; } set { movement = value; } }
    public Equipment Equipment { get { return equipment; } set { equipment = value; } }
    public AnimatorController DefaultController { get { return defaultController; } set { defaultController = value; } }
    public Action Action { get { return action; } set { action = value; } }

    public void Start()
    {
        state = new CharacterState();
    }
}
