﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ClickToChangeText : MonoBehaviour {

	[SerializeField] int targetSceneNumber;
	[SerializeField] Text[] textList;
	int activatedObj = 0;

	void Start () {
		foreach (Text list in textList) {
			list.gameObject.SetActive (false);
		}

		if (textList [activatedObj] != null) {
			textList [activatedObj].gameObject.SetActive (true);
		}

	}

	void Update () {
		if (Input.GetMouseButtonUp (0)) {
			textList [activatedObj].gameObject.SetActive (false);
			activatedObj++;
			if (textList.Length>activatedObj) {
				textList [activatedObj].gameObject.SetActive (true);
			} else {
				//go to new scene...?
				//Debug.Log ("Text abis");
				Application.LoadLevel(targetSceneNumber);
				if (targetSceneNumber == 0) {
					GameObject.Find ("GameControl").GetComponent<GameControl> ().ResetScore();
					//GameObject.Find ("GameControl").GetComponent<GameControl> ().WriteToXML();
					GameObject.Find ("GameControl").GetComponent<GameControl> ().WriteJSON();
				}
			}
		}
	}
}