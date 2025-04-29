using UnityEngine;

public class TerminalEnter : MonoBehaviour
{
    [SerializeField]
    private GameObject terminal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Terminal" && terminal != null)
        {
            Cursor.visible = true;
            terminal.SetActive(true);
        }
    }
}
