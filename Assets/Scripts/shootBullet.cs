using UnityEngine;
using System.Collections;

public class shootBullet : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject BulletSpawn;
    public GameObject aimLine;

    public AudioSource gunfire;
    public AudioSource ammoDry;
    public AudioSource reloadSoundEffect;

    public int maxAmmo;
    [HideInInspector]public int currentAmmo;
    [HideInInspector]public bool reloading = false;

    public Canvas canvas;
    
    IEnumerator reload()
    {
        reloading = true;
        reloadSoundEffect.Play();
        yield return new WaitForSeconds(3);

        currentAmmo = maxAmmo;
        reloading = false;
    }
    

    void Start()
    {
        reloading = false;
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if(!canvas.GetComponent<canvasScript>().paused)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo > 0 && !reloading)
                {
                    gunfire.Play();
                    Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
                    //Time.timeScale = 0.0f;
                    --currentAmmo;
                }
                else if (currentAmmo <= 0 || reloading)
                {
                    ammoDry.Play();
                }
            }

            if (Input.GetMouseButtonDown(1))
            {
                aimLine.SetActive(true);
            }
            if (Input.GetMouseButtonUp(1))
            {
                aimLine.SetActive(false);
            }

            if (Input.GetKey(KeyCode.R) && !reloading)
            {
                StartCoroutine(reload());
            }
        }
    }
}
