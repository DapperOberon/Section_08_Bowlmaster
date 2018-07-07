using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> rolls = new List<int>();

	private ScoreDisplay scoreDisplay;
	private PinSetter pinSetter;
	private BowlingBall ball;

	// Use this for initialization
	void Start () {
		scoreDisplay = FindObjectOfType<ScoreDisplay>();
		pinSetter = FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<BowlingBall>();
	}
	
	public void Bowl(int pinFall)
	{

			rolls.Add(pinFall);
			ball.Reset();
			pinSetter.PerformAction(ActionMaster.NextAction(rolls));


		try
		{
			scoreDisplay.FillRolls(rolls);
			scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
		} catch
		{
			Debug.LogWarning("Something went wrong in FillRoll()");
		}
	}
}
