using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action { Tidy, Reset, EndTurn, EndGame };

	public Action Bowl(int pins)
	{
		if(pins < 0 || pins > 10)
		{
			throw new UnityException("Incorrect number of pins. Must be between 0 and 10");
		}

		if (pins == 10)
		{
			return Action.EndTurn;
		}

		throw new UnityException("Not sure what action to return!");
	}
}
