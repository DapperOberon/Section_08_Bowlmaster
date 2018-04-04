using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text pinText;
	private Pin[] pins;
	
	// Update is called once per frame
	void Update () {
		pinText.text = string.Format("Standing Pins: {0}", CountStanding());
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
}
