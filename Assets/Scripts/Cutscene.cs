using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene : MonoBehaviour
{
    //private Dictionary<int, string> names = 

    private void OnEnable()
    {
        string lvlName = SceneManager.GetActiveScene().name;
        int lvlIndex = int.Parse(lvlName[lvlName.Length - 1].ToString());
        Debug.Log($"Index: {lvlIndex}");
        PlayerPrefs.SetInt("Vova", 1);
        Time.timeScale = 0f;
    }
}