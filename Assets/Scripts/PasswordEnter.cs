using TMPro;
using UnityEngine;

public class PasswordEnter : MonoBehaviour
{
    [SerializeField]
    private string correctPassword;
    [SerializeField]
    private GameObject cutscene;
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

    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(player.GetComponent<PlayerMovement>());
        player.GetComponent<Rigidbody2D>().Sleep();
    }

    private bool IsCorrect()
    {
        return pwd == correctPassword;
    }
    
    private void ExitPwdPannel()
    {
        Cursor.visible = false;
        pwd = "";
        text.text = "";
        animator.SetBool("Wrong", false);
        transform.parent.parent.gameObject.SetActive(false);
    }
}
