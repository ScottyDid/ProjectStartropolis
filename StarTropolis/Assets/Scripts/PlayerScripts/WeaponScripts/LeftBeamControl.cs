using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBeamControl : MonoBehaviour
{
	private float xInput, yInput;

	[SerializeField]
	private bool canFire;

	[SerializeField]
	private float chargeUp, chargeRate, fireTime;

	public GameObject beam;

	public Transform fireSpawnL;

	// Use this for initialization
	void Start()
	{
		canFire = false;
		fireTime = 5f;
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
			chargeUp += Time.deltaTime * chargeRate;

			if (chargeUp >= 50f)// && Time.time > canFireBeam)
			{
				canFire = true;
				ShootBeam();
			}

			if(canFire == true)
            {
				fireTime -= Time.deltaTime * chargeRate;
			}
		}
	}

	public void ShootBeam()
	{
		beam.gameObject.SetActive(true);
		chargeUp = 0f;
        if(fireTime <= 0f)
        {
			beam.gameObject.SetActive(false);
			canFire = false;
			fireTime = 5f;
		}
	}
}
