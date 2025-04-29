using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOver;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Enemy" && !collision.gameObject.tag.Contains("Dragon"))
            return;
            
        gameOver.SetActive(true);
    }
}
