using UnityEngine;

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
    [SerializeField]
    private AudioSource jumpSound;
    private Animator animator;
    private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private bool isGrounded = false, isMoving = false;
    private float speed;
    private Rigidbody2D elevator;
    private PlayerLocker locker;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var i in GetComponentsInChildren<Animator>())
        {
            if (transform != i.transform)
            {
                animator = i;
                break;
            }
        }

        rb = GetComponent<Rigidbody2D>();
        locker = GetComponent<PlayerLocker>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    public void Jump()
    {
        if (!locker.Locked && isGrounded)
        {
            jumpSound.Play();
            rb.AddForce(new Vector2(.0f, jumpForce));
        }
    }


    void FixedUpdate()
    {
        float direction = locker.Locked ? 0f : ArrowsInput.Direction;
        CheckFlip(direction);
        isMoving = !Mathf.Approximately(direction, 0f);
        animator.SetBool("Walk", isMoving);
        speed = Mathf.Lerp(speed, direction * maxSpeed, Time.fixedDeltaTime * smoothedMovementFactor);
        Vector3 translate = new Vector3(speed * Time.fixedDeltaTime, .0f, 0f);
        float elevatorSpeed = elevator != null ? elevator.linearVelocityX : 0f;
        rb.linearVelocityX = speed + elevatorSpeed;
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
