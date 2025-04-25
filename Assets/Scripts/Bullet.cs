using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GameObject enemy = collision.gameObject;
            enemy.GetComponent<Animator>().SetTrigger("Dead");
            enemy.GetComponent<Rigidbody2D>().freezeRotation = false;
            Destroy(enemy.GetComponent<ZombieMovement>());
            enemy.tag = "Untagged";
        }

        GetComponent<Animator>().enabled = false;
        Destroy(gameObject, 4f);
    }
}
