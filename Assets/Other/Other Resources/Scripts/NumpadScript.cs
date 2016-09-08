using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class NumpadScript : MonoBehaviour {
	//variables for box 1 and box 2
	public GameObject AngkaA, AngkaB;
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

	int getTextToInt(GameObject gameObject) {
		Text text = gameObject.GetComponent<Text> ();
		return int.Parse (text.text);
	}
}
