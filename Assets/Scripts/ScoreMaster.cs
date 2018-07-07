using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

	public static List<int> ScoreCumulative(List<int> rolls)
	{
		List<int> scoreTotal = new List<int>();
		int runningTotal = 0;

		foreach(int frameScore in ScoreFrames(rolls))
		{
			runningTotal += frameScore;
			scoreTotal.Add(runningTotal);
		}

		return scoreTotal;
	}

	public static List<int> ScoreFrames (List<int> rolls)
	{
		List<int> frames = new List<int>();

		// Index i points to 2nd bowl of frame
		for (int i = 1; i < rolls.Count; i += 2)
		{
			if(frames.Count == 10) { break; }						// Prevents 11th frame

			if (rolls[i - 1] + rolls[i] < 10)						// Normal "open" frame
			{ 
				frames.Add(rolls[i - 1] + rolls[i]);
			}

			if(rolls.Count - i <= 1) { break; }						// Not enough lookahead

			if(rolls[i-1] == 10)									// Strike Bonus
			{
				i--;												// Reset i to first bowl becuase strike only has 1
				frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
			} else if (rolls[i - 1] + rolls[i] == 10)				// Spare Bonus
			{
				frames.Add(10 + rolls[i+1]);
			}
		}

		return frames;
	}
}
