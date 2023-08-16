using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftScatterControl : MonoBehaviour
{
	private float xInput, yInput;
	private float canFireBullet = 0f;

	public GameObject pellet;
	public int pelletCount;
	public Transform fireSpawnL;

	[SerializeField]
	private float shootDelay = 1f, spreadAngle = 45f;
	
	List<Quaternion> pellets;

    private void Awake()
    {
		pellets = new List<Quaternion>(pelletCount);
		for (int i = 0; i < pelletCount; i++)
        {
			pellets.Add(Quaternion.Euler(Vector2.zero));
        }
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

		if (inputs.magnitude > 1f && Time.time > canFireBullet)
		{
			ShootScatter();
		}
	}

	void ShootScatter()
	{
		float angleStep = spreadAngle / pelletCount;
		float aimingAngle = fireSpawnL.rotation.eulerAngles.z;
		float centreingOffset = (spreadAngle / 2) - (angleStep / 2);

		canFireBullet = Time.time + shootDelay;

		for (int i = 0; i < pelletCount; i++)
        {
			float currentPelletAngle = angleStep * i;

			Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, aimingAngle + currentPelletAngle - centreingOffset));
			GameObject Pellet = Instantiate(pellet, fireSpawnL.position, rotation);
        }
	}
}