using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pause;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pause != null)
        {
            Cursor.visible = true;
            pause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void Continue()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        pause.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
