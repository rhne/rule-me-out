using UnityEngine;
using System.Collections;
using System;

public class QuestionSet : MonoBehaviour {
	int questionLength = 12;
	int selectedQuestion;
	System.Random rnd;

	// Use this for initialization
	void Start () {
		rnd = new System.Random ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpinQuestionWheel() {
		selectedQuestion = rnd.Next (questionLength);
	}

	public int GetAnswer(int a, int b) {
		int result = -666;
		switch(selectedQuestion) {
		case 1:
			result = a + b;
			break;
		case 2: //sum of digits
			result = a;
			break;
		case 3:
			result = Mathf.Abs (a - b);
			break;
		case 4:
			result = a * b;
			break;
		case 5: //a/b
			result = b;
			break;
		case 6:
			result = a % b;
			break;
		case 7:
			result = b % a;
			break;
		case 8:
			result = (a + b) % 2;
			break;
		case 9:
			if (a > b)
				result = a;
			else 
				result = b;
			break;
		case 10:
			if (a < b)
				result = a;
			else 
				result = b;
			break;
		case 11:
			if (a > b)
				result = 1;
			else
				result = 0;
			break;
		case 12:
			if (a < b)
				result = 1;
			else
				result = 0;
			break;
		};
		return result;
	}
}
