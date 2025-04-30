using UnityEngine;
using UnityEngine.Events;

public class MessageReaded : MonoBehaviour
{
    [SerializeField]
    private UnityEvent<bool> playLockActions;
    
    public void Readed()
    {
        playLockActions.Invoke(false);
        Destroy(gameObject);
        Cursor.visible = false;
        Time.timeScale = 1f;
    }
}
