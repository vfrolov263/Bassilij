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

    void Start()
    {
        readyToShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && readyToShoot)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody2D>().AddForceX( transform.parent.localScale.x * shootForce);
            StartCoroutine(Reload());
            readyToShoot = false;
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        readyToShoot = true;
    }
}
