﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public float settleTime = 2f;
	private float lastChangeTime;


	public Text pinText;
	public GameObject pinSet;
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

	public void RaisePins()
	{
		Debug.Log("Raising pins");

		foreach (Pin p in GameObject.FindObjectsOfType<Pin>())
		{
			p.Raise();
		}
	}

	public void LowerPins()
	{
		Debug.Log("Lowering pins");

		foreach (Pin p in GameObject.FindObjectsOfType<Pin>())
		{
			p.Lower();
		}
	}

	public void RenewPins()
	{
		Debug.Log("Renewing pins");

		Instantiate(pinSet, new Vector3(0, 0.5f, 18.29f), Quaternion.identity);
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