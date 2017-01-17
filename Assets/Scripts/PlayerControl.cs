using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    public float maxBooster;
    public float boosterRechargeRate;
    public float boosterUsageRate;
	public float moveSpeed;   // units per second
	public float rotationSpeed;  // degrees per second
    public float JumpSpeed;

    public float horizontalRotationSensitivity;
    public float verticalRotationSensitivity;

    [HideInInspector]public float remainingBooster;

    public Canvas canvas;

    void Start()
    {
        UnityEngine.Cursor.visible = false;
        remainingBooster = maxBooster;
    }
	
	// Update is called once per frame
	void Update()
	{
        //transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * rotationSensitivity);

        float horizontal = horizontalRotationSensitivity * Input.GetAxis("Mouse X");
        float vertical = verticalRotationSensitivity * -Input.GetAxis("Mouse Y");
        transform.Rotate(vertical, horizontal, 0);

        if (Input.GetKey(KeyCode.W))
        {
			transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.S))
        {
			transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.D))
        {
			transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKey(KeyCode.A))
        {
			transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
		}




        if(!canvas.GetComponent<canvasScript>().paused)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (remainingBooster > 0)
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * JumpSpeed);
                    remainingBooster -= boosterUsageRate * Time.deltaTime;
                }
            }
            else
            {
                if (remainingBooster < maxBooster)
                {
                    remainingBooster += boosterRechargeRate * Time.deltaTime;
                }
            }
        }
    }
}
