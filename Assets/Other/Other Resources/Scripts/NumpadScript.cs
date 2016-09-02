using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class NumpadScript : MonoBehaviour {
	//variables for box 1 and box 2
	public GameObject AngkaA, AngkaB;
	GameObject currentAngka;
	bool _switch;
	int attempt = 10;

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
		Debug.Log (display.Length);
		updateText (display);
	}

	public void EnterOnClick() {
		//input: A and B
		//get result from question
		//concatenate into string
		//update text
		if (attempt > 0) {
			int A = getTextToInt (AngkaA);
			int B = getTextToInt (AngkaB);
			String result = A + "\t" + B.ToString () + "\t" + QuestionSet.GetAnswer (A, B);
			Debug.Log (result);
			attempt--;
		}
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
		return Int32.Parse (text.text);
	}
}
