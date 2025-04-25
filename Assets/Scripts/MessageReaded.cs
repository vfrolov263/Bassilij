using UnityEngine;

public class MessageReaded : MonoBehaviour
{
    public void Readed()
    {
        Destroy(gameObject);
        Time.timeScale = 1f;
    }
}
