using UnityEngine;
using System.Collections;

public class BulletMovement : MonoBehaviour
{

	public float moveSpeed;
    public float bulletLasts;
    float destroyTime = Time.time;

    Transform rot;

    // Use this for initialization
    void Start()
	{
        destroyTime = Time.time + bulletLasts;
        rot = GetComponent<Rigidbody>().transform;
	}

    //void OnCollisionEnter(Collision coll)
    //{
        //transform.forward = Vector3.Reflect(coll.gameObject.transform.forward, Vector3.right);
    //}

    // Update is called once per frame
    void Update()
	{
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        //GetComponent<Rigidbody>().velocity = transform.forward * moveSpeed;
        transform.rotation = rot.rotation;
        //GetComponent<Rigidbody>().AddForce(transform.forward * moveSpeed);
        if (Time.time >= destroyTime)
        {
            Destroy(gameObject);
        }
	}
}
