using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold = .97f;
	public float distanceToRaise = 0.5f;
	private Rigidbody rb;

	private void Start()
	{
		rb = this.GetComponent<Rigidbody>();
		if (!rb) { Debug.LogError(this.name + ": Cannot find Rigidbody"); }
		rb.useGravity = true;
	}
	public bool IsStanding()
	{
		return (transform.up.y > standingThreshold);
	}

	public void Raise()
	{
		if (IsStanding())
		{
			rb.useGravity = false;
			rb.constraints = RigidbodyConstraints.FreezeAll;
			transform.Translate(0, distanceToRaise, 0);
		}
	}

	public void Lower()
	{
		if (IsStanding())
		{
			transform.Translate(0, -distanceToRaise, 0);
			rb.useGravity = true;
			rb.constraints = RigidbodyConstraints.None;
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		Destroy(gameObject);
	}
}
