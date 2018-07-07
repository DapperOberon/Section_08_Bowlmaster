using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollScores, frameScores;

	public void FillRolls(List<int> rolls)
	{
		string rollString = FormatRolls(rolls);

		for(int i = 0; i < rolls.Count; i++)
		{
			rollScores[i].text = rollString[i].ToString();
		}
	}

	public void FillFrames(List<int> frames)
	{
		for(int i = 0; i < frames.Count; i++)
		{
			frameScores[i].text = frames[i].ToString();
		}
	}

	public static string FormatRolls(List<int> rolls)
	{
		string output = "";

		for (int i = 0; i < rolls.Count; i++)
		{
			int box = output.Length + 1;                            // Score box 1 to 21

			if (rolls[i] == 0)                                      // Zero roll
			{
				output += "-";
			} 
			else if ((box % 2 == 0 || box == 21) && rolls[i - 1] + rolls[i] == 10)
			{
				output += "/";                                      // Spare
			}
			else if (box >= 19 && rolls[i] == 10)
			{
				output += "X";                                      // Strike in last frame
			}
			else if (rolls[i] == 10)
			{
				output += "X ";                                     // Strike: space skips next bowl
			}
			else
			{
				output += rolls[i].ToString();						// Normal roll
			}
			
		}

		return output;
	}
}
