using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;
	public float distanceToRaise = 0.5f;

	public bool IsStanding()
	{
		float xTilt = Mathf.Abs(transform.rotation.eulerAngles.x);
		float zTilt = Mathf.Abs(transform.rotation.eulerAngles.z);

		if(xTilt < standingThreshold || zTilt < standingThreshold)
		{
			return true;
		}
		else
		{
			return false;
		}	
	}

	public void Raise()
	{
		if (IsStanding())
		{
			GetComponent<Rigidbody>().useGravity = false;
			transform.Translate(0, distanceToRaise, 0);
		}
	}

	public void Lower()
	{
		if (IsStanding())
		{
			transform.Translate(0, -distanceToRaise, 0);
			GetComponent<Rigidbody>().useGravity = true;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		Destroy(gameObject);
	}
}
