using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 4f;

    private Rigidbody2D mRb;
    private Vector3 mDirection = Vector3.zero;
    private Animator mAnimator;

    private void Start()
    {
        mRb = GetComponent<Rigidbody2D>();
        mAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        mAnimator.SetFloat("Horizontal", mDirection.x);
        mAnimator.SetFloat("Vertical", mDirection.y);
    }

    private void FixedUpdate()
    {
        mRb.MovePosition(
            transform.position + (mDirection * speed * Time.fixedDeltaTime)
        );
    }

    public void OnMove(InputValue value)
    {
        mDirection = value.Get<Vector2>().normalized;
    }
}
