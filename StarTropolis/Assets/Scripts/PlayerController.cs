using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float speed = 2.0f;
	public float shieldTimer;

	private Transform city;

	public GameObject shield;



	// Use this for initialization
	void Start()
	{
		city = GetComponent<Transform>();
		shield.SetActive(false);
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

		if (Input.GetButtonDown("Shield"))
        {
			StartCoroutine(ShieldUp());
        }
	}

	IEnumerator ShieldUp()
    {
		shield.SetActive(true);
		yield return new WaitForSeconds(shieldTimer);
		shield.SetActive(false);
    }
}
