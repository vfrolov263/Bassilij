using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PasswordEnter : MonoBehaviour
{
    [SerializeField]
    private string correctPassword;
    [SerializeField]
    private GameObject cutscene;
    [SerializeField]
    private UnityEvent<bool> playLockActions;
    private string pwd;
    private TMP_Text text;
    private Animator animator;
    private AudioSource wrongSound;
    
    void Start()
    {
        pwd = "";
        text = GetComponent<TMP_Text>();
        animator = GetComponent<Animator>();
        wrongSound = GetComponent<AudioSource>();
    }

    public void Click(int digit)
    {
        if (pwd.Length >= correctPassword.Length)
            return;

        pwd += digit.ToString();
        text.text = pwd;

        if (pwd.Length < correctPassword.Length)
            return;
        
        if (IsCorrect())
        {
            LockPlayer();
            if (cutscene != null) cutscene.SetActive(true);
            Destroy(transform.parent.parent.gameObject);
        }
        else
        {
            if (!wrongSound.isPlaying) wrongSound.Play();
            animator.SetBool("Wrong", true);
            Invoke("ExitPwdPannel", 2f);
        }

    }

    private void LockPlayer()
    {
        GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<Rigidbody2D>().Sleep();
    }

    private bool IsCorrect()
    {
        return pwd == correctPassword;
    }
    
    private void ExitPwdPannel()
    {
        playLockActions.Invoke(false);
        Cursor.visible = false;
        pwd = "";
        text.text = "";
        animator.SetBool("Wrong", false);
        transform.parent.parent.gameObject.SetActive(false);
    }
}
