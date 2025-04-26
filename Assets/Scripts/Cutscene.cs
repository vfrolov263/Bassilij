using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    [SerializeField]
    private GameParams gameParams;

    private void OnEnable()
    {
        string lvlName = SceneManager.GetActiveScene().name;
        int lvlIndex = int.Parse(lvlName[lvlName.Length - 1].ToString());
        PlayerPrefs.SetInt(gameParams.GetNameByIndex(lvlIndex - 1), 1);
        Time.timeScale = 0f;
    }
}