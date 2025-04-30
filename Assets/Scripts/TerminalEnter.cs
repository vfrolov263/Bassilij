using UnityEngine;
using UnityEngine.Events;

public class TerminalEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject terminal;
    [SerializeField]
    private UnityEvent<bool> playLockActions;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terminal" && terminal != null && !terminal.activeSelf)
        {
            playLockActions.Invoke(true);
            Cursor.visible = true;
            terminal.SetActive(true);
        }
    }
}
