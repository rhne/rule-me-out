using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class NumpadScript : MonoBehaviour {
	//variables for box 1 and box 2
	public GameObject AngkaA, AngkaB, Answer;
	GameObject currentAngka;
	bool _switch;

	string display = "";

	void Start() {
		currentAngka = AngkaA;
		currentAngka.GetComponent<Text>().color = Color.yellow;
		_switch = true;
	}

	//function for numpad button on click
	public void ButtonOnClick(GameObject button) {
		if (_switch) {
			display = button.name;
			_switch = false;
		} else if(display.Length<3) {
			display = display + button.name;
		}
		updateText (display);
	}

	public void AnswerInput(GameObject button) {

	}

	public void EnterOnClick() {
		//input: A and B
		//get result from question: to diffscript
		//concatenate into string
		//update text

		//just make sure we have nice working existing int a and b
		//attempt constraint isn't also going to be processed here.
		//TODO: update more exception handlings here
		int A = getTextToInt (AngkaA);
		int B = getTextToInt (AngkaB);


		//instead of going straight to challenger, go to attempt history
		//please fix this
		int askQuestion = GameObject.Find ("Manager").GetComponent<AttemptHistory> ().AskQuestion(A,B);

		//for debugging sake only
		String result = A + "\t" + B.ToString () + "\t" + askQuestion;
		Debug.Log (result);
		//
	}

	public void SignOnClick() {
		//toggle between AngkaA and AngkaB
		_switch = true;
		currentAngka.GetComponent<Text>().color = Color.white;
		Debug.Log("sign");
		if (currentAngka == AngkaA)
			currentAngka = AngkaB;
		else
			currentAngka = AngkaA;
		currentAngka.GetComponent<Text>().color = Color.yellow;
	}

	void updateText(string newText) {
		Text angka = currentAngka.GetComponent<Text> ();
		angka.text = newText;
	}

	public void updateAngkaA(string newText) {
		Text angka = AngkaA.GetComponent<Text> ();
		angka.text = newText;
	}

	public void updateAngkaB(string newText) {
		Text angka = AngkaB.GetComponent<Text> ();
		angka.text = newText;
	}

	public void updateAnswer(string newText) {
		Text angka = Answer.GetComponent<Text> ();
		angka.text += newText;
	}

	public void resetAnswer() {
		Text angka = Answer.GetComponent<Text> ();
		angka.text = "";
	}

	public void checkAnswer() {
		Text angka = Answer.GetComponent<Text> ();
		//get the fucking answer, and then check it to challenger. but we need to store the selected question
		if (angka.text == PlayerPrefs.GetInt ("Real Answer").ToString()) {
			Debug.Log ("Correct!");
			angka.text = "Correct!";
		} else {
			Debug.Log ("Wrong Answer");
			angka.text = "Wrong Answer";
		}
	}

	int getTextToInt(GameObject gameObject) {
		Text text = gameObject.GetComponent<Text> ();
		return int.Parse (text.text);
	}
}
