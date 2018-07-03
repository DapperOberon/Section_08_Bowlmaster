using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterBall : MonoBehaviour {

	private PinSetter pinSetter;

	private void Start()
	{
		pinSetter = GameObject.FindObjectOfType<PinSetter>();
	}

	private void OnTriggerExit(Collider collider)
	{
		if(collider.gameObject.CompareTag("BowlingBall"))
		{
			pinSetter.SetBallEnteredBox();
		}
	}
}
