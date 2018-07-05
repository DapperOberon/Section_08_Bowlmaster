using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private List<int> bowls = new List<int>();

	private PinSetter pinSetter;
	private BowlingBall ball;

	// Use this for initialization
	void Start () {
		pinSetter = FindObjectOfType<PinSetter>();
		ball = FindObjectOfType<BowlingBall>();
	}
	
	public void Bowl(int pinFall)
	{
		bowls.Add(pinFall);

		ActionMaster.Action nextAction = ActionMaster.NextAction(bowls);
		pinSetter.PerformAction(nextAction);
		ball.Reset();
	}
}
