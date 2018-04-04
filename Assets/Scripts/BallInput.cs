using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BowlingBall))]
public class BallInput : MonoBehaviour {

	private float startTime, endTime;
	private Vector3 startPos, endPos;

	private BowlingBall ball;
	// Use this for initialization
	void Start () {
		ball = GetComponent<BowlingBall>();
	}
	
	public void DragStart()
	{
		// Capture time & postition of drag start
		startTime = Time.time;
		startPos = Input.mousePosition;
		Debug.Log("Start: " + startTime + ", " + startPos);
	}

	public void DragEnd()
	{
		// Launch the ball
		endTime = Time.time;
		endPos = Input.mousePosition;

		float dragDuration = endTime - startTime;
		float xVelocity = (endPos.x - startPos.x) / dragDuration / 100;
		float zVelocity = (endPos.y - startPos.y) / dragDuration / 100;
		Mathf.Clamp(xVelocity, 0, ball.maxSpeed);
		Mathf.Clamp(zVelocity, 0, ball.maxSpeed);

		Vector3 velocity = new Vector3(xVelocity, 0, zVelocity);

		Debug.Log("End: " + dragDuration + ", " + velocity);

		ball.Launch(velocity);
	}

	public void MoveStart(float xNudge)
	{
		if (!ball.bHasLaunched)
		{
			float newXPos = Mathf.Clamp(ball.transform.position.x + xNudge, -.525f, .525f);
			//Mathf.Clamp(newXPos, -0.525f, 0.525f);
			ball.transform.position = new Vector3(newXPos, ball.transform.position.y, ball.transform.position.z);
			Debug.Log("Nudge amount: " + newXPos);
		}
		
	}
}
