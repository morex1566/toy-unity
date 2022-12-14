using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEditor.TextCore.Text;
using UnityEngine;

abstract public class Movement
{
    static public Stand stand = null;
    static public Walk walk = null;
    static public Run run = null;

    [SerializeReference] protected CharacterRoot root;

    protected Vector3 directionForMove;
    protected Vector3 directionForAnimate;
    protected delegate float calculateAccel(float maxSpeed_, float coefficient_);
    protected calculateAccel accel;


    // Pls call at once!
    static public void CreateMovement(CharacterRoot root_)
    {
        if (stand == null) { stand = new Stand(ref root_); }
        if (walk == null) { walk = new Walk(ref root_); }
        if (run == null) { run =new Run(ref root_); } 
    }

    abstract public void HandleInput();
    abstract public void Initialize();
    abstract public void InnerUpdate();
    abstract public void UpdateDirty();
    abstract public void Move();
    abstract public void Rotate();
    abstract public void Animate();


    // Member method for child
    protected void switchMovementTo(ref Movement movement_)
    {
        root.Movement = movement_;
    }

    protected void rotateToMousePosition()
    {
        Vector3 worldPosition;
        Vector3 direction;
        Quaternion fromRotation;
        Quaternion toRotation;
        Ray ray;
        Plane plane;
        float distance;

        plane = new Plane(Vector3.up, 0);
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            direction = worldPosition - root.transform.position;

            fromRotation = root.transform.rotation;
            toRotation = Quaternion.LookRotation(direction);

            root.transform.rotation = Quaternion.Lerp(fromRotation,
                toRotation,
                root.MovementData.RotateSpeed * Time.fixedDeltaTime
            );
        }

    }

    protected void addDirection(Vector3 directionForMove_, Vector3 directionForAnimate_)
    {
        directionForMove += directionForMove_;
        directionForAnimate += directionForAnimate_;
    }

    protected float accelerate(float maxSpeed_, float coefficient_)
    {
        if(root.State.Speed < maxSpeed_) { root.State.Speed += coefficient_ * Time.fixedDeltaTime; }

        return root.State.Speed;
    }

    protected float decelerate(float maxSpeed_, float coefficient_)
    {
        if(root.State.Speed > 0) { root.State.Speed -= coefficient_ * Time.fixedDeltaTime; }
        if(root.State.Speed <= 0) { root.State.Speed = 0; }

        return root.State.Speed;
    }
}
