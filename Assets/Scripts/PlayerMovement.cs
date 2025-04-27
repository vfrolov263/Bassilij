using UnityEngine;
using Prime31;
using System;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float maxSpeed = 5f;
    [SerializeField]
    private float jumpForce = 350f;
    [SerializeField]
    private Transform bottom;
    [SerializeField]
    private float smoothedMovementFactor = 5f;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private bool isGrounded = false;
    private float speed;
    private Rigidbody2D elevator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemies"), LayerMask.NameToLayer("Enemies"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Drop"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Bullets"), LayerMask.NameToLayer("Drop"));
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Drop"), LayerMask.NameToLayer("Drop"));

        foreach (var i in GetComponentsInChildren<Animator>())
        {
            if (transform != i.transform)
            {
                animator = i;
                break;
            }
        }

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        CheckFlip(direction);
        animator.SetBool("Walk", !Mathf.Approximately(direction, 0f));
        speed = Mathf.Lerp(speed, direction * maxSpeed, Time.deltaTime * smoothedMovementFactor);
        //Vector3 translate = new Vector3(speed * Time.deltaTime, .0f, 0f);
        float elevatorSpeed = elevator != null ? elevator.linearVelocityX : 0f;
        rb.linearVelocityX = speed + elevatorSpeed;

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(new Vector2(.0f, jumpForce));
    }

    void FixedUpdate()
    {
        float verticalSpeed = rb.linearVelocityY;
        if (verticalSpeed < 0f && verticalSpeed > -0.05f) verticalSpeed = 0f;
        animator.SetFloat("VerticalSpeed", verticalSpeed);
    }

    private void CheckFlip(float direction)
    {
        if (direction * transform.localScale.x < 0f)
            transform.localScale = new Vector3( -transform.localScale.x, transform.localScale.y, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;

        if (collision.tag == "Elevator")
            RideElevator(collision.gameObject.GetComponent<Rigidbody2D>());

        isGrounded = true;
        animator.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger)
            return;

        if (collision.tag == "Elevator")
            LeaveElevator();

        isGrounded = false;
        animator.SetBool("Grounded", isGrounded);
    }

    private void RideElevator(Rigidbody2D elevator)
    {
        if (elevator.linearVelocityX != 0)
            this.elevator = elevator;
    }

    private void LeaveElevator()
    {
        elevator = null;
    }
}
