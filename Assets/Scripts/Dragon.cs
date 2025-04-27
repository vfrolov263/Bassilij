using System.Collections;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject sleepAnimation;
    [SerializeField]
    private float fireTime = 2f;
    private int health = 4;
    private float maxHealth;
    private SpriteRenderer sprite;
    private Transform shooterTransform;

    private void Start()
    {
        Collider2D collider = GetComponent<Collider2D>();
        collider.excludeLayers = LayerMask.GetMask("Bullets");
        sprite = GetComponent<SpriteRenderer>();
        maxHealth = health;
        shooterTransform = transform.GetChild(0);
        StartCoroutine(Fire());
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
            StopAllCoroutines();
            Animator anim = GetComponent<Animator>();
            anim.SetTrigger("Sleep");
            Destroy(GetComponent<Collider2D>());
            Invoke("Sleep", anim.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    private IEnumerator Fire()
    {
        yield return new WaitForSeconds(fireTime);

        while (true)
        {
            Instantiate(bullet, shooterTransform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireTime);
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
