using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 2.0f;
	private Transform city;
	public GameObject shield;
	public GameObject dome;

	//[SerializeField]
	//private int;

	[SerializeField]
	private float shieldTimer, domeEnergy, domeIncrease;

	[SerializeField]
	private Material fullDome, thirdDome, halfDome, quarterDome;


	// Use this for initialization
	void Start()
	{
		city = GetComponent<Transform>();
		shield.SetActive(false);
		//domeEnergy = 100;
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 moveVectorLeft = new Vector3(Input.GetAxis("HorizontalLeft"), 0, 0);
		city.transform.position -= moveVectorLeft * speed * Time.deltaTime;
		Vector3 moveVectorRight = new Vector3(Input.GetAxis("HorizontalRight"), 0, 0);
		city.transform.position += moveVectorRight * speed * Time.deltaTime;

		if (city.transform.position.x <= -20f)
		{
			transform.position = new Vector3(-20, 0, 0);
		}

		if (city.transform.position.x >= 20f)
		{
			transform.position = new Vector3(20, 0, 0);
		}

		if (Input.GetButton("Shield"))
        {
			StartCoroutine(ShieldUp());
        }
		DomeControl();
	}

	void DomeControl()
    {
		domeEnergy += domeIncrease * Time.deltaTime;
		
		if (domeEnergy >= 100)
        {
			domeEnergy = 100;
        }
		if (domeEnergy <= 100)
		{
			dome.GetComponent<Renderer>().material = fullDome;
		}
		if (domeEnergy <= 75)
        {
			dome.GetComponent<Renderer>().material = thirdDome;
        }
		if (domeEnergy <= 50)
		{
			dome.GetComponent<Renderer>().material = halfDome;
		}
		if (domeEnergy <= 25)
		{
			dome.GetComponent<Renderer>().material = quarterDome;
		}
		if (domeEnergy <= 0)
		{
			dome.SetActive(false);
			domeEnergy = 0;
		}
		else
        {
			dome.SetActive(true);
        }
	}

	IEnumerator ShieldUp()
    {
		shield.SetActive(true);
		yield return new WaitForSeconds(shieldTimer);
		shield.SetActive(false);
    }
}
