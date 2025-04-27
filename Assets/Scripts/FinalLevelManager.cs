using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalLevelManager : MonoBehaviour
{
    public void LoadOutro()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Outro");
    }
}
