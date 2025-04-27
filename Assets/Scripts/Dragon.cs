using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField]
    private GameObject sleepAnimation;

    private int health = 4;
    private float maxHealth;
    private SpriteRenderer sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.excludeLayers = LayerMask.GetMask("Bullets");
        sprite = GetComponent<SpriteRenderer>();
        maxHealth = health;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Drop"))
            return;

        health--;
        Destroy(collision.gameObject);
        ChangeColor();

        if (health <= 0)
        {
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Sleep");
            Destroy(GetComponent<Collider2D>());
            Invoke("Sleep", anim.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    private void Sleep()
    {
        sleepAnimation.SetActive(true);
    }

    private void ChangeColor()
    {
        float lessColor = 1f - (1f / maxHealth) * (maxHealth - health);
        sprite.color = new Color(1f, lessColor, lessColor, 1f);
    }
}
