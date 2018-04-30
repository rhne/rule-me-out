using UnityEngine;
using System.Collections.Generic;
using System;
using System.Diagnostics;

public class ChallengeController : MonoBehaviour {
	[SerializeField] bool EnableRandomQuestion;
	private int curQuestionIndex;

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
		//randomise the list
		int selectedQuestion;
		if (EnableRandomQuestion) {
			selectedQuestion = UnityEngine.Random.Range (0, questionList.Count);
		} else {
			selectedQuestion = Math.Max(PlayerPrefs.GetInt("CurrentQuestionIndex") + 1, 0) % questionList.Count; 
		}
		rule = questionList[selectedQuestion];
		PlayerPrefs.SetInt ("CurrentQuestionIndex", selectedQuestion);

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
