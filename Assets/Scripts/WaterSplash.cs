using UnityEngine;

public class WaterSplash : MonoBehaviour
{
    private AudioSource splash;

    void Start()
    {
        splash = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player" && !splash.isPlaying)
            splash.Play();
    }
}
