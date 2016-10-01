using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumpadScript : MonoBehaviour {
	//variables for box 1 and box 2
	public GameObject AngkaA, AngkaB, Answer;
	GameObject currentAngka;
	bool _switch, _nextStageClickable, _answerStatus;

	string display = "";

	void Start() {
		currentAngka = AngkaA;
		currentAngka.GetComponent<Text>().color = Color.yellow;
		_switch = true;
		_nextStageClickable = false;
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

		//if isAttempted, change colors into red
		if (GameObject.Find ("Manager").GetComponent<AttemptHistory> ().isAttempted (A, B)) {
			AngkaA.GetComponent<Text> ().color = Color.red;
			AngkaB.GetComponent<Text> ().color = Color.red;
		}

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
		//get the answer, and then check it to challenger. but we need to store the selected question
		if (angka.text == PlayerPrefs.GetInt ("Real Answer").ToString()) {
			angka.text = "Correct!";
			_answerStatus = true;
			GameObject gameControl = GameObject.Find ("GameControl");
			gameControl.GetComponent<GameControl> ().AddScore (1);
			gameControl.GetComponent<GameControl>().UpdateQuestionsCorrectCount(PlayerPrefs.GetInt("CurrentQuestionIndex"));


		} else {
			angka.text = "Wrong Answer";
			_answerStatus = false;
			
		}

		//change answer text to "click me to continue"
		//and then make the person clickable. there'll be a kind of activation parameter in the script somewhere.
		Text clickMeText = GameObject.Find("Click me text").GetComponent<Text> ();
		clickMeText.text = "Click Me to Continue";
		_nextStageClickable = true;
		GameObject.Find ("GameControl").GetComponent<GameControl> ().PlayCountIncrement();
	}

	public bool IsToNextStageEnabled() {
		return _nextStageClickable;
	}

	public bool IsRightAnswer() {
		return _answerStatus;
	}

	int getTextToInt(GameObject gameObject) {
		Text text = gameObject.GetComponent<Text> ();
		return int.Parse (text.text);
	}
}
