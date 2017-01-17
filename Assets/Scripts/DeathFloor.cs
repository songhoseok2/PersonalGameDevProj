using UnityEngine;
using System.Collections;



public class DeathFloor : MonoBehaviour
{
    public AudioSource enemyDeathSound;

    void OnCollisionEnter(Collision coll)
    {
        Destroy(coll.gameObject);

        if (coll.gameObject.name == "player")//coll.CompareTag("Player_tag"))
        {
            Application.LoadLevel("game over");
        }
        else
        {
            //AudioSource.PlayClipAtPoint(enemyDeathSound, Camera.main.transform.position);
            enemyDeathSound.Play();
        }
    }
}
