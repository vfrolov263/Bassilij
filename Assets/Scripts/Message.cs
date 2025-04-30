using UnityEngine;
using UnityEngine.Events;

public class Message : MonoBehaviour
{
    [SerializeField]
    private GameObject message;
    [SerializeField]
    private UnityEvent<bool> playLockActions;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
            return;
            
        playLockActions.Invoke(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        message.SetActive(true);
        Destroy(gameObject);
    }
}
