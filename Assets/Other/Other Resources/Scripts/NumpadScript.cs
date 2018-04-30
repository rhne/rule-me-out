using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumpadScript : MonoBehaviour {
	//variables for box 1 and box 2
	public GameObject AngkaA, AngkaB, Answer;
	public GameObject ErrMessage01; // ask player to input other combination

	GameObject currentAngka;
	private bool _switch, _isAnswerAlreadyGiven, _answerStatus;

	string display;

	void Start() {
		display = "";
		currentAngka = AngkaA;
		currentAngka.GetComponent<Text>().color = Color.yellow;
		_switch = true;
		_isAnswerAlreadyGiven = false;

		ErrMessage01.SetActive (false);
	}

	//function for numpad button on click during function trials
	public void ButtonOnClick(GameObject button) {
		if (_switch) {
			display = button.name;
			_switch = false;
		} else if(display.Equals("0")) {
			display = button.name;
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
			//AngkaA.GetComponent<Text> ().color = Color.red;
			//AngkaB.GetComponent<Text> ().color = Color.red;
			ErrMessage01.SetActive (true);
		} else {
			ErrMessage01.SetActive (false);
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

	public void AngkaAOnClick() {
		//if selected is already angka A
		if (currentAngka != AngkaA) {
			_switch = true;
			currentAngka.GetComponent<Text>().color = Color.white;
			currentAngka = AngkaA;
			currentAngka.GetComponent<Text>().color = Color.yellow;
		}
	}

	public void AngkaBOnClick() {
		if (currentAngka != AngkaB) {
			_switch = true;
			currentAngka.GetComponent<Text>().color = Color.white;
			currentAngka = AngkaB;
			currentAngka.GetComponent<Text>().color = Color.yellow;
		}
	}

	public void DeleteOnClick() {
		display = "0";
		updateText (display);
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

	#region Answer Page
	public void updateAnswer(string newText) {
		if (_isAnswerAlreadyGiven)
			return;

		Text angka = Answer.GetComponent<Text> ();
		angka.text += newText;
		
	}

	public void resetAnswer() {
		if (_isAnswerAlreadyGiven)
			return;
		
		Text angka = Answer.GetComponent<Text> ();
		angka.text = "";
	}

	public void checkAnswer() {
		Text angka = Answer.GetComponent<Text> ();
		if (angka.text.Equals ("") || _isAnswerAlreadyGiven) {
			// input error, should contain something
			// TODO: tambah popup error message ke player or smth
			return;
		}

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
		_isAnswerAlreadyGiven = true;
		GameObject.Find ("GameControl").GetComponent<GameControl> ().PlayCountIncrement();
	}

	public bool IsToNextStageEnabled() {
		return _isAnswerAlreadyGiven;
	}

	public bool IsRightAnswer() {
		return _answerStatus;
	}

	#endregion

	int getTextToInt(GameObject gameObject) {
		Text text = gameObject.GetComponent<Text> ();
		int angka;
		int.TryParse (text.text, out angka);
		if (angka <= 0) {
			angka = 0;
			text.text = "0";
		}
		return angka;
	}
}
