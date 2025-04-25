using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField]
    float speed = 3f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
       // Vector2 translate = new Vector2(speed * Time.deltaTime, .0f);
        rb.linearVelocityX = speed;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "EnemyTrigger")
            return;

        speed = -speed;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 1f);
    }

    // private void OnColliderEnter2D(Collider2D collider)
    // {
    //     if (collider.gameObject.tag == "Enemy")
    //         Phys
    // }
}
