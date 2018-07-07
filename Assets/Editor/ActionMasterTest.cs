using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls;

	[SetUp]
	public void Setup()
	{
		pinFalls = new List<int>();
	}

	//[Test]
	//public void T00PassingTest()
	//{
	//	Assert.AreEqual(1, 1);
	//}

	//[Test]
	//public void T01StrikeReturnsEndTurn()
	//{
	//	pinFalls.Add(10);
	//	Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(pinFalls));
	//}

	//[Test]
	//public void T02Bowl8ReturnsTidy()
	//{
	//	pinFalls.Add(8);
	//	Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.NextAction(pinFalls));
	//}

	//[Test]
	//public void T03Bowl82SpareReturnsEndTurn()
	//{
	//	int[] rolls = { 8, 2 };
	//	Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T04GutterTidy()
	//{
	//	int[] rolls = { 2, 0 };
	//	Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T05CheckResetStrikeLastFrame()
	//{
	//	int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10 };
	//	Assert.AreEqual(ActionMaster.Action.Reset, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T06CheckResetSpareLastFrame()
	//{
	//	int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9 };
	//	Assert.AreEqual(ActionMaster.Action.Reset, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T07EndGame()
	//{
	//	int[] rolls = { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 10, 8, 2, 9 };
	//	Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T08GameEndAt20()
	//{
	//	int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
	//	Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T09EndGame()
	//{
	//	int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 5 };
	//	Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T10EndGame()
	//{
	//	int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 0 };
	//	Assert.AreEqual(ActionMaster.Action.Tidy, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T11Nathan10PinSecondBowl()
	//{
	//	int[] rolls = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 10, 5, 1 };
	//	Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T12Dondi10thFrameTurkey()
	//{
	//	int[] rolls = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 10, 10, 10 };
	//	Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(rolls.ToList()));
	//}

	//[Test]
	//public void T13ZeroOneGivesEndTurn()
	//{
	//	int[] rolls = { 0, 1 };
	//	Assert.AreEqual(ActionMaster.Action.EndTurn, ActionMaster.NextAction(rolls.ToList()));
	//}
}