using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float shootForce = 400f;
    [SerializeField]
    private float reloadTime = 2f;
    private bool readyToShoot;
    private AudioSource shootSound;
    private PlayerLocker locker;

    void Start()
    {
        readyToShoot = true;
        shootSound = GetComponent<AudioSource>();
        locker = transform.parent.GetComponent<PlayerLocker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            Shoot();
    }

    public void Shoot()
    {
        if (locker.Locked || !readyToShoot)
            return;

        shootSound.Play();
        GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        newBullet.GetComponent<Rigidbody2D>().AddForceX( transform.parent.localScale.x * shootForce);
        StartCoroutine(Reload());
        readyToShoot = false;
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        readyToShoot = true;
    }
}
