using UnityEngine;

public class Message : MonoBehaviour
{
    [SerializeField]
    private GameObject message;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
            
        Time.timeScale = 0f;
        message.SetActive(true);
        Destroy(gameObject);
    }
}
