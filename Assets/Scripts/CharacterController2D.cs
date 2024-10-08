using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    [SerializeField] float speed = 2f;
    
    Vector2 motionVector;
    Animator animator;

    public Vector2 lastMotionVector;
    public bool isMoving = false;
    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Debug.Log("Velocity " + rigidbody2D.velocity.ToString());

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        motionVector.x = horizontal;
        motionVector.y = vertical;
       
        isMoving = horizontal != 0 || vertical != 0;
        animator.SetBool("isMoving", isMoving);

        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        if (isMoving == true)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;

            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }



    //Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody2D.velocity = motionVector * speed;
    }

    //private void OnDisable()
    //{
    //    rigidbody2D.velocity = Vector2.zero;
    //}

    //private void OnEnable()
    //{
    //    StartCoroutine(Movement());
    //}

    //IEnumerator Movement()
    //{
    //    Move();
    //}
}
