using UnityEngine;
using System.Collections.Generic;
using System;

public class ChallengeController : MonoBehaviour {
	

	delegate int Rule(int x, int y);
	List<Rule> questionList = new List<Rule> () {
		QuestionSet.Sum,
		QuestionSet.SumOfDigit,
		QuestionSet.Smallest,
		QuestionSet.ModofSum,
		QuestionSet.AbsSubstraction,
		QuestionSet.Multiply,
		QuestionSet.AModB,
		QuestionSet.BModA,
		QuestionSet.Largest,
		QuestionSet.AIsLarger,
		QuestionSet.BIsLarger
	};

	private Rule rule;
	private int _challengeA, _challengeB;

	public int ChallengeA {
		get {
			return _challengeA;
		}
		set {
			_challengeA = value;
		}
	}

	public int ChallengeB {
		get {
			return _challengeB;
		}
		set {
			_challengeB = value;
		}
	}

	// Use this for initialization
	void Start () {
		// Here be Test Case
		// TODO: load from DB or somewhere else

		//randomise the list
		int selectedQuestion = UnityEngine.Random.Range(0,questionList.Count);
		rule = questionList[selectedQuestion];

		//Debug.Assert(CheckAnswer(5)); // Largest of 5 and 3 is 5
		//Debug.Assert(AskQuestion(19, 2) == 19);
		//Debug.Assert(AskQuestion(3, 5) == 5); // Inverted challenge should be okay.

		// challenge should NOT be okay.
		try
		{
			//Debug.Assert(AskQuestion(5,3) == 5); // Should throw exception
			//Debug.Assert(false); // Shouldn't happen, as above should give exception
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
		if (x == ChallengeA && y == ChallengeB) {
			throw new ArgumentException("That is the question, don't ask me!");
		}
		else {
			return rule(x,y);
		}
	}

	public bool CheckAnswer(int answer) {
		return (rule(ChallengeA, ChallengeB) == answer);
	}

	//called by answer button
	public void SaveRealAnswer() {
		PlayerPrefs.SetInt ("Real Answer", rule (ChallengeA, ChallengeB));
	}

}
