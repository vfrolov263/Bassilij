using UnityEngine;

public class Dragonfire : MonoBehaviour
{
    [SerializeField]
    private float speed;

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        Destroy(gameObject);
    }
}
