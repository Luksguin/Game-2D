using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public SOPlayerSetup soPlayerSetup;
    public Rigidbody2D myRigdbody;
    public Animator animator;
    public ParticleSystem systemParticle;
    public Vector2 friction = new Vector2(.1f, 0);

    [Header("Collider Jump Setup")]
    public Collider2D myCollider;
    public float distToGround;
    public float spaceToGround;

    private float _currentSpeed;

    private void Awake()
    {
        if (myCollider != null)
        {
            distToGround = myCollider.bounds.extents.y;
        }
    }

    void Update()
    {
        isGrounded();
        Jump();
        Moviments();
    }

    private bool isGrounded()
    {
        Debug.DrawRay(transform.position + Vector3.up * .1f, -Vector2.up, Color.magenta, distToGround + spaceToGround);
        return Physics2D.Raycast(transform.position + Vector3.up * .1f, -Vector2.up, distToGround + spaceToGround);
    }

    public void Moviments()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = soPlayerSetup.speedRun;
        }
        else
        {
            _currentSpeed = soPlayerSetup.speed;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            myRigdbody.velocity = new Vector2(+_currentSpeed, myRigdbody.velocity.y);
            myRigdbody.transform.localScale = new Vector2(1, 1);
            animator.SetBool(soPlayerSetup.boolRun, true);

            if (systemParticle != null)
            {
                systemParticle.transform.localScale = new Vector2(1, 1);
                systemParticle.Play();
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            myRigdbody.velocity = new Vector2(-_currentSpeed, myRigdbody.velocity.y);
            myRigdbody.transform.localScale = new Vector2(-1, 1);
            animator.SetBool(soPlayerSetup.boolRun, true);

            if (systemParticle != null)
            {
                systemParticle.transform.localScale = new Vector2(-1, 1);
                systemParticle.Play();
            }
        }
        else
        {
            animator.SetBool(soPlayerSetup.boolRun, false);
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            myRigdbody.velocity = Vector2.up * soPlayerSetup.forceJump;
            myRigdbody.transform.localScale = Vector2.one;

            DOTween.Kill(myRigdbody.transform);

            animator.SetBool(soPlayerSetup.boolJump, true);

            jumpScale();
        }
        else
        {
            animator.SetBool(soPlayerSetup.boolJump, false);
        }
    }

    public void jumpScale()
    {
        myRigdbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
        myRigdbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
    }
}
