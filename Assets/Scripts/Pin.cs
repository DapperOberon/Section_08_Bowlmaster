using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = 5f;

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

	private void OnTriggerExit(Collider collider)
	{
		Destroy(gameObject);
	}
}
