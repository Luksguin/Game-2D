using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Speed")]
    public Rigidbody2D myRigdbody;
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed;
    public float speedRun;
    public float forceJump;

    [Header("Animations")]
    public float jumpScaleY;
    public float jumpScaleX;
    public float animationDuration;

    [Header("Animations States")]
    public Animator animator;
    public string boolRun;

    public string boolJump;

    private float _currentSpeed;
    private Ease ease = Ease.OutBack;

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
            myRigdbody.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(boolRun, true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigdbody.velocity = new Vector2(-_currentSpeed, myRigdbody.velocity.y);
            myRigdbody.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(boolRun, true);
        }
        else
        {
            animator.SetBool(boolRun, false);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigdbody.velocity = Vector2.up * forceJump;
            myRigdbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigdbody.transform);

            animator.SetBool(boolJump, true);

            jumpScale();
        }
        else
        {
            animator.SetBool(boolJump, false);
        }
    }

    public void jumpScale()
    {
        myRigdbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        myRigdbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }
}
