using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Equipment : MonoBehaviour
{
    [SerializeField] protected AnimatorOverrideController equipmentController;
    [SerializeField] protected Vector3 offsetPosition, offsetRotation;
    [SerializeField] protected Collider rootingRange, dealingRange, physicsRange;
    [SerializeField] protected Rigidbody rigid;
    [SerializeField] public ParticleSystem leftSlashParticle;
    [SerializeField] public ParticleSystem rightSlashParticle;

    public void Equiped(CharacterRoot root_)
    {
        rootingRange.enabled = false;
        physicsRange.enabled = false;
        dealingRange.enabled = true;

        rigid.isKinematic = true;

        transform.localPosition = offsetPosition;
        transform.localRotation = Quaternion.Euler(offsetRotation);

        root_.Animator.runtimeAnimatorController = equipmentController;
    }
    public void Dropped(CharacterRoot root_)
    {
        rootingRange.enabled = true;
        physicsRange.enabled = true;
        dealingRange.enabled = false;

        rigid.isKinematic = false;

        root_.Animator.runtimeAnimatorController = root_.DefaultController;
    }
}
