using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NumpadScript : MonoBehaviour {
	//variables for box 1 and box 2
	public GameObject AngkaA, AngkaB;
	GameObject currentAngka;

	string display = "";

	void Start() {
		currentAngka = AngkaA;
		currentAngka.GetComponent<Text>().color = Color.yellow;
	}

	public void ButtonOnClick(GameObject button) {
		display = button.name;
		Debug.Log (display);
		updateText (display);
	}

	public void EnterOnClick() {

	}

	public void SignOnClick() {
		//toggle between AngkaA and AngkaB
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
