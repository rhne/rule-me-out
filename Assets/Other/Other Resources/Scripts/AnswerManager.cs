using UnityEngine;
using System.Collections;

public class AnswerManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.Find ("AngkaA").GetComponent<NumpadScript> ().updateAngkaA(PlayerPrefs.GetInt("ChallengeA").ToString());
		GameObject.Find ("AngkaA").GetComponent<NumpadScript> ().updateAngkaB(PlayerPrefs.GetInt("ChallengeB").ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
