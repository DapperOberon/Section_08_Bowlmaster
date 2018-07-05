using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMaster {

	public enum Action { Tidy, Reset, EndTurn, EndGame };

	public static Action NextAction(List<int> pinFalls)
	{
		ActionMaster am = new ActionMaster();
		Action currentAction = new Action();

		foreach(int pinFall in pinFalls)
		{
			currentAction = am.Bowl(pinFall);
		}

		return currentAction;
	}

	private int[] bowls = new int[21];
	private int bowl = 1;

	private Action Bowl(int pins) // TODO make private
	{
		if(pins < 0 || pins > 10) { throw new UnityException("Incorrect number of pins. Must be between 0 and 10"); }

		bowls[bowl - 1] = pins;

		// Bowl 21
		if(bowl == 21)
		{
			return Action.EndGame;
		}

		//if (bowl == 20 && Bowl21Awarded())
		//{
		//	bowl += 1;
		//	return Action.Tidy;
		//}

		// Bowl 19 or 20 and got a spare
		if(bowl >= 19 && pins == 10)
		{
			bowl += 1;
			return Action.Reset;
		} else if (bowl == 20) // Bowl 20 and did not get a spare
		{
			bowl += 1;
			if(bowls[19-1] == 10 && bowls[20-1] == 0) // Strike on bowl 19 but not strike on bowl 20
			{
				return Action.Tidy;
			}
			else if ((bowls[19 - 1] + bowls[20 - 1]) % 10 == 0) // Spare or strike
			{
				return Action.Reset;
			} else if (IsBowl21Awarded())
			{
				return Action.Tidy;
			} else // End Game
			{
				return Action.EndGame;
			}
		}
		
		if(bowl % 2 != 0) // First bowl of frame
		{
			if(pins == 10)
			{
				bowl += 2; // Because it skips one bowl and goes to next frame
				return Action.EndTurn;
			} else
			{
				bowl += 1; // Moves to next bowl
				return Action.Tidy;
			}
		} else if (bowl % 2 == 0) // Second bowl of frame
		{
			bowl += 1;
			return Action.EndTurn;
		}

		throw new UnityException("Not sure what action to return!");
	}

	

	private bool IsBowl21Awarded()
	{
		// Remember that arrays start counting at zero
		return (bowls[19 - 1] + bowls[20 - 1] >= 10);
	}
}
