using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBeamControl : MonoBehaviour
{
	private float xInput, yInput;

	public GameObject beam;

	public Transform fireSpawnL;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//Get the left joysticks input.
		Vector2 inputs = new Vector3(Input.GetAxis("LstickVertical"), Input.GetAxis("LstickHorizontal"));

		//If the force on the stick is more then 1, code happens.
		if (inputs.magnitude > 1f)
		{
			//Get the angles from the two inputs.
			float inputAngle = (Mathf.Atan2(inputs.y, inputs.x) * Mathf.Rad2Deg);
			//Rotate the turret on the z-axis.
			transform.localEulerAngles = new Vector3(0, 0, inputAngle);
		}

		if (inputs.magnitude > 1f)// && Time.time > canFireBeam)
		{
			ShootBeam();
		}
        else
        {
			beam.gameObject.SetActive(false);
        }
	}

	void ShootBeam()
	{
		beam.gameObject.SetActive(true);
	}
}
