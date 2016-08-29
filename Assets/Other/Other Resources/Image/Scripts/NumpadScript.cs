using UnityEngine;
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
		Debug.Log (display.Length);
		updateText (display);
	}

	public void EnterOnClick() {

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
}
