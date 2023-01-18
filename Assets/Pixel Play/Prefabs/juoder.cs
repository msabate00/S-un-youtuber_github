using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class juoder : MonoBehaviour
{

	public Transform target;
	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		Vector3 playerAngle = new Vector3(transform.forward.x, 0.0f, transform.forward.z);
		Vector3 cameraAngle = new Vector3(Camera.main.transform.forward.x, 0.0f, Camera.main.transform.forward.z);
		float horizDiffAngle = Vector3.Angle(playerAngle, cameraAngle);

		// Rotate the character to face the camera direction
		if (horizDiffAngle > 80)
		{
			Quaternion playerDestAngle = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y, transform.eulerAngles.z);
			transform.rotation = Quaternion.Lerp(transform.rotation, playerDestAngle, Time.deltaTime * 3);
		}

		// Match the character y-axis rotation with camera if moving
		if (cameraAngle.x != 0 || cameraAngle.z != 0)
			transform.rotation = Quaternion.Euler(transform.eulerAngles.x, Camera.main.transform.eulerAngles.y - 5, transform.eulerAngles.z);
	}
}