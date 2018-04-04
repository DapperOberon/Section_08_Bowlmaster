using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

	public BowlingBall ball;

	private Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = gameObject.transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (ball.transform.position.z <= 18.29f)
		{
			gameObject.transform.position = ball.transform.position + offset;
		}	
	}
}
