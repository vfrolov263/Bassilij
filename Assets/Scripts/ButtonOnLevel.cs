using UnityEngine;

public class ButtonOnLevel : MonoBehaviour
{
    [SerializeField]
    private Animator doorAnimator;
    [SerializeField]
    private Sprite pressedSprite;
    [SerializeField]
    private bool multiuse = false;
    private Sprite activeSprite;
    private bool pressed = false;

    private void Start()
    {
        activeSprite = GetComponent<SpriteRenderer>().sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bullet" || pressed)
            return;

        GetComponent<SpriteRenderer>().sprite = pressedSprite;
        doorAnimator.SetBool("Open", true);

        if (!multiuse)
        {
            Destroy(transform.GetChild(0).gameObject);
            Destroy(GetComponent<Collider2D>());
            return;
        }

        pressed = true;
        Invoke("Activate", 3f);
    }

    private void Activate()
    {
        GetComponent<SpriteRenderer>().sprite = activeSprite;
        doorAnimator.SetBool("Open", false);
        pressed = false;
    }
}