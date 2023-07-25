using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightBeamControl : MonoBehaviour
{
	private float xInput, yInput;
	//private float canFireBullet = 1f;

	public GameObject beam;

	public Transform fireSpawnR;

	[SerializeField]
	//private float shootDelay = 1f;
	//private float scatterOffSet = Random.Range(-10f, 10f);

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		//Get the left joysticks input.
		Vector2 inputs = new Vector3(Input.GetAxis("RstickVertical"), Input.GetAxis("RstickHorizontal"));

		//If the force on the stick is more then 1, code happens.
		if (inputs.magnitude > 1f)
		{
			//Get the angles from the two inputs.
			float inputAngle = (Mathf.Atan2(inputs.y, inputs.x) * Mathf.Rad2Deg);
			//Rotate the turret on the z-axis.
			transform.localEulerAngles = new Vector3(0, 0, inputAngle);
		}

		if (inputs.magnitude > 1f) //&& Time.time > canFireBullet)
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
		//canFireBullet = Time.time + shootDelay;
		beam.gameObject.SetActive(true);

		//projectile.transform.rotation *= Quaternion.Euler(0f, 0f, Random.Range(-10, 10f));
	}
}
