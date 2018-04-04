using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public float settleTime = 2f;
	private float lastChangeTime;

	public Text pinText;
	private Pin[] pins;
	private BowlingBall ball;
	private bool bBallEnteredBox = false;

	private void Start()
	{
		ball = GameObject.FindObjectOfType<BowlingBall>();
	}

	// Update is called once per frame
	void Update () {
		pinText.text = string.Format("Standing Pins: {0}", CountStanding());

		if (bBallEnteredBox)
		{
			
			CheckStanding();
		}
	}

	public int CountStanding()
	{
		int standingPinCount = 0;

		foreach(Pin p in GameObject.FindObjectsOfType<Pin>())
		{
			if (p.IsStanding())
			{
				standingPinCount++;
			}
		}

		return standingPinCount;
	}

	public void CheckStanding()
	{
		int pinCount = CountStanding();
		if (pinCount != lastStandingCount)
		{
			lastChangeTime = Time.time;
			lastStandingCount = pinCount;
			return;
		}

		if ((Time.time - lastChangeTime) > settleTime)
		{
			PinsHaveSettled();
		}	
	}

	public void PinsHaveSettled()
	{
		ball.Reset();
		lastStandingCount = -1; // Pins settles (new frame)
		bBallEnteredBox = false;
		pinText.color = Color.green;
	}

	private void OnTriggerEnter(Collider collider)
	{
		if (collider.CompareTag("BowlingBall"))
		{
			bBallEnteredBox = true;
			pinText.color = Color.red;
		}
	}
}
