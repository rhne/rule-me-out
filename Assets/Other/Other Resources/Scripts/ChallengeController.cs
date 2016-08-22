﻿using UnityEngine;
using System.Collections;
using System;

public class ChallengeController : MonoBehaviour {

	delegate int Rule(int x, int y);

	private Rule rule;
	private int _challengeA, _challengeB;

	public int ChallengeA {
		get {
			return _challengeA;
		}
	}

	public int ChallengeB {
		get {
			return _challengeB;
		}
	}

	// Use this for initialization
	void Start () {
		// Here be Test Case
		// TODO: load from DB or somewhere else
		rule = Largest;
		_challengeA = 5;
		_challengeB = 3;

		Debug.Assert(CheckAnswer(5)); // Largest of 5 and 3 is 5
		Debug.Assert(AskQuestion(19, 2) == 19);
		Debug.Assert(AskQuestion(3, 5) == 5); // Inverted challenge should be okay.

		// challenge should NOT be okay.
		try
		{
			Debug.Assert(AskQuestion(5,3) == 5); // Should throw exception
			Debug.Assert(false); // Shouldn't happen, as above should give exception
		}
		catch (ArgumentException e)
		{
			// When asked with _challengeA and _challengeB, should go here
			// And does nothing.
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	// Give answer only if it's not the challenge
	public int AskQuestion (int x, int y) {
		if (x != ChallengeA && y != ChallengeB) {
			return rule(x,y);
		}
		else {
			throw new ArgumentException("That is the question, don't ask me!");
		}
	}

	public bool CheckAnswer(int answer) {
		return (rule(ChallengeA, ChallengeB) == answer);
	}

	#region ChallengeQuestions
	private int Largest(int x, int y) {
		return Mathf.Max(x,y);
	}

	private int Smallest(int x, int y) {
		return Mathf.Min(x,y);
	}
	#endregion
}