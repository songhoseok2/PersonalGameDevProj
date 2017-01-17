using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Transform lookAt;
    public Transform camTransform;


    //private float distance = 5.0f;
    //private float currentX = 0.0f;
    //private float currentY = 0.0f;
    //private float sensitivityX = 5.0f;
    //private float sensitivityY = 5.0f;

    void Start ()
    {
        camTransform = transform;
	}
	
	void Update ()
    {
        //currentX += Input.GetAxis("Mouse X") * sensitivityX;
        //currentY += Input.GetAxis("Mouse Y") * sensitivityY;


    }

    void LateUpdate()
    {
        //Vector3 dir = new Vector3(0, 0, -distance);
        //Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        //cam.transform.position = lookAt.position + rotation * dir;

        camTransform.LookAt(lookAt.position);
    }
}
