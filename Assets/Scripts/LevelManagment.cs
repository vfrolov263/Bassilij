using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManagment : MonoBehaviour
{
    [SerializeField]
    private PlayerFigurine player;
    [SerializeField]
    private GameObject buttons;
    private int levelToLoad = -1;

    void OnEnable()
    {
        string[] names = {"Max", "Vova", "Gleb", "Nikita", "Nastya"};
        int nextLevel = 0;

        foreach (var i in names)
        {
            if (PlayerPrefs.GetInt(i) == 0)
                break;

            nextLevel++;
        }

        if (nextLevel == names.Length)
            return;

        SetOnButtonAnim(nextLevel);
    }

    private void SetOnButtonAnim(int index)
    {
        var anims = buttons.GetComponentsInChildren<Animator>();
        anims[index].SetTrigger("Next");

        if (index > 0)
            player.SetPosition(anims[index - 1].gameObject.GetComponent<RectTransform>());

        for (int i = index + 1; i < anims.Length; i++)
            anims[i].gameObject.GetComponent<Button>().interactable = false;
    }

    public void LoadLevel(int index)
    {
        if (levelToLoad != -1)
            return;

        levelToLoad = index;
        var buttonTransforms = buttons.GetComponentsInChildren<RectTransform>();

        if (index >= buttonTransforms.Length)
            return;

        player.SetDestination(buttonTransforms[index]);
        Invoke("LoadLevel", player.GetReadyTime());
        player.Move();
    }

    private void LoadLevel()
    {
        if (levelToLoad != -1)
            SceneManager.LoadScene($"Level{levelToLoad}");
    }
}
