using UnityEngine;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField]
    private Vector2 speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ElevatorTrigger")
            speed = -speed;
    }
}
