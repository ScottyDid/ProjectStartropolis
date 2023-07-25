using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class gun_control : MonoBehaviour 
{

	private float xInput, yInput;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 inputs = new Vector3 (Input.GetAxis ("LstickVertical"), Input.GetAxis ("LstickHorizontal"));

		if (inputs.magnitude > 0.2f)
		{
			float inputAngle = (Mathf.Atan2(inputs.y, inputs.x) * Mathf.Rad2Deg);
			transform.localEulerAngles = new Vector3(0, 0, inputAngle);
		}
	}
}
