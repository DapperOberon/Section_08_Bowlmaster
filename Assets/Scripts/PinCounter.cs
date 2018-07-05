using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public int lastStandingCount = -1;
	public int lastSettledCount = 10;
	public float settleTime = 2f;
	private float lastChangeTime;

	public Text pinText;
	private bool bBallOutOfPlay = false;

	private GameManager gameManager;

	private void Start()
	{
		gameManager = GameObject.FindObjectOfType<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		pinText.text = string.Format("Standing Pins: {0}", CountStanding());

		if (bBallOutOfPlay)
		{
			CheckStanding();
		}
	}

	private void OnTriggerExit(Collider collider)
	{
		if (collider.gameObject.CompareTag("BowlingBall"))
		{
			bBallOutOfPlay = true;
			pinText.color = Color.red;
		}
	}

	public int CountStanding()
	{
		int standingPinCount = 0;

		foreach (Pin p in GameObject.FindObjectsOfType<Pin>())
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
		int standing = CountStanding();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		gameManager.Bowl(pinFall);

		lastStandingCount = -1; // Pins settles (new frame)
		bBallOutOfPlay = false;
		pinText.color = Color.green;
	}

	public void ResetPinCount()
	{
		lastSettledCount = 10;
	}
}
