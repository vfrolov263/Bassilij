using UnityEngine;

public class MessageReaded : MonoBehaviour
{
    public void Readed()
    {
        Destroy(gameObject);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
