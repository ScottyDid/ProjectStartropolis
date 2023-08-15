using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftGunControl : MonoBehaviour
{
	private float xInput, yInput;
	private float canFireBullet = 0f;

	public GameObject projectile;
	public Transform fireSpawnL;

	[SerializeField]
	private float shootDelay = 1f;

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
		
		//If the force on the stick is more then 1, and if the time is greater then canFireBullet
		if (inputs.magnitude > 1f && Time.time > canFireBullet)
        {
			//Pew Pew
			ShootProjectile();
        }
	}

	void ShootProjectile()
	{
		//canFireBullet is the same as time plus shoot delay value
		canFireBullet = Time.time + shootDelay;
		//create bullet, at gun barrel position, using guns rotation
		Instantiate(projectile, fireSpawnL.position, fireSpawnL.rotation);
	}
}
