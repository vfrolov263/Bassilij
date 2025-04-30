using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pause;
    [SerializeField]
    private UnityEvent<bool> playLockActions;
    private bool prevCursorVisible;
    private float prevTimeScale;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseOn();
    }

    public void PauseOn()
    {
        if (pause == null || pause.activeSelf == true)
            return;

        playLockActions.Invoke(true);
        prevCursorVisible = Cursor.visible;
        prevTimeScale = Time.timeScale;
        Cursor.visible = true;
        pause.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        playLockActions.Invoke(false);
        Cursor.visible = prevCursorVisible;
        Time.timeScale = prevTimeScale;
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
