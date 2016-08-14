using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumpadScript : MonoBehaviour {
	//variables for box 1 and box 2

	string display = "";

	public void ButtonOnClick(GameObject button) {
		display = button.name;
		Debug.Log (display);
		updateText (display);
	}

	void EnterOnClick() {

	}

	void SignOnClick() {

	}

	void updateText(string newText) {
		Text angka = gameObject.GetComponent<Text> ();
		angka.text = newText;
	}
}
