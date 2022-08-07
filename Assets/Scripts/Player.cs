using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigdbody;

    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;

    private float _currentSpeed;

    private bool _isJumpping = false;

    void Update()
    {
        Jump();
        Moviments();
    }

    public void Moviments()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigdbody.velocity = new Vector2(+_currentSpeed, myRigdbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigdbody.velocity = new Vector2(-_currentSpeed, myRigdbody.velocity.y);
        }

        if(myRigdbody.velocity.x > 0)
        {
            myRigdbody.velocity += friction;
        }
        else if((myRigdbody.velocity.x < 0))
        {
            myRigdbody.velocity -= friction;
        }
    }

    public void Jump()
    {
        if(_isJumpping == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                myRigdbody.velocity = Vector2.up * forceJump;
                _isJumpping = true;
            }

        }
    }
}
