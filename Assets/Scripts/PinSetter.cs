using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;
	private Pin[] pins;

	private PinCounter pinCounter;
	private Animator animator;

	private void Start()
	{
		pinCounter = FindObjectOfType<PinCounter>();
		animator = this.GetComponent<Animator>();
	}

	public void RaisePins()
	{
		foreach (Pin p in GameObject.FindObjectsOfType<Pin>())
		{
			p.Raise();
		}
	}

	public void LowerPins()
	{
		foreach (Pin p in GameObject.FindObjectsOfType<Pin>())
		{
			p.Lower();
		}
	}

	public void RenewPins()
	{
		Instantiate(pinSet, new Vector3(0, 0.5f, 18.29f), Quaternion.identity);
	}

	public void PerformAction(ActionMaster.Action action)
	{
		if (action == ActionMaster.Action.Tidy)
		{
			animator.SetTrigger("tidyTrigger");
		}
		else if (action == ActionMaster.Action.EndTurn)
		{
			animator.SetTrigger("resetTrigger");
			pinCounter.ResetPinCount();
		}
		else if (action == ActionMaster.Action.Reset)
		{
			animator.SetTrigger("resetTrigger");
			pinCounter.ResetPinCount();
		}
		else if (action == ActionMaster.Action.EndGame)
		{
			Debug.Log("End of Game!");
			//throw new UnityException("Don't know how to handle end game scenario");
		}
	}
}
