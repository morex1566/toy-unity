using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed;
    private float hp;
    private float mp;

    public float MoveSpeed { get { return moveSpeed; } set { moveSpeed = value; } }
    public float HP { get { return hp; } set { hp = value; } }
    public float MP { get { return mp; } set { mp = value; } }

    PlayerMovement()
    {
        moveSpeed = 10.0f;
        hp = 100.0f;
        mp = 100.0f;
    }

    ~PlayerMovement()
    {

    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        move(calculateMovement());
    }

    private Vector3 calculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        return new Vector3(-verticalInput, 0f, horizontalInput);
    }

    private void move(Vector3 direction)
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}