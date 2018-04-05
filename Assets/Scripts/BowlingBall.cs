using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour {

	public float maxSpeed;
	public bool bHasLaunched = false;
	private Rigidbody rb;
	private AudioSource audioSource;
	private bool bHitGround = false;
	private Vector3 startPos;

	// Use this for initialization
	void Start ()
	{
		rb = this.GetComponent<Rigidbody>();
		if (!rb) { Debug.LogError(this.name + ": Cannot find a rigibody attached!"); }
		rb.useGravity = false;
		audioSource = this.GetComponent<AudioSource>();
		if (!audioSource) { Debug.LogWarning(this.name + ": Cannot find an audiosource!"); }

		startPos = transform.position;
	}

	public void Launch(Vector3 velocity)
	{
		bHasLaunched = true;
		rb.useGravity = true;
		rb.velocity = velocity;
	}

	public void Reset()
	{
		Debug.Log("Reseting ball");
		transform.position = startPos;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		bHasLaunched = false;
		bHitGround = false;
		rb.useGravity = false;
	}

	private void OnCollisionEnter()
	{
		if (!bHitGround)
		{
			audioSource.Play();
			bHitGround = true;
		}
	}
}
