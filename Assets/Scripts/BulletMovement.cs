using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

	public float moveSpeed = 20f;
    public float bulletLasts;
    float destroyTime = Time.time;

    // Use this for initialization
    void Start()
	{
        destroyTime = Time.time + bulletLasts;
	}
	
	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if(Time.time >= destroyTime)
        {
            Destroy(gameObject);
        }
	}
    /*
	public void OnTriggerEnter(Collider coll)
	{
		if (coll.CompareTag("Enemy"))
        {
			AudioSource.PlayClipAtPoint(enemyDeathSound, transform.position);
			Destroy(coll.gameObject);
			Destroy(this.gameObject);
		}
	}
    */
}
