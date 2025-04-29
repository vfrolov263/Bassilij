using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    [SerializeField]
    GameParams gameParams;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (PlayerPrefs.GetInt(gameParams.GetNameByIndex(0)) != 0)
            LoadMenu();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}