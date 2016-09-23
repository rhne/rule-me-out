using UnityEngine;
using System.Collections;
using System;

public class QuestionSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ChallengeGenerator ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void ChallengeGenerator() {
		//this.GetComponent<GetComponent<ChallengeController> ().ChallengeA = Random.Range (0, 20);
		int number = UnityEngine.Random.Range (0, 20);
		GameObject.Find ("Manager").GetComponent<ChallengeController> ().ChallengeA = number;
		GameObject.Find ("AngkaA").GetComponent<NumpadScript> ().updateAngkaA(number.ToString());
		PlayerPrefs.SetInt ("ChallengeA", number);

		number = UnityEngine.Random.Range (0, 20);
		GameObject.Find ("Manager").GetComponent<ChallengeController> ().ChallengeB = number;
		GameObject.Find ("AngkaA").GetComponent<NumpadScript> ().updateAngkaB(number.ToString());
		PlayerPrefs.SetInt ("ChallengeB", number);
	}

	private static int SumOfDigit (int x) {
		int sum = 0;
		while (x != 0) {
			sum += x % 10;
			x /= 10;
		}

		return sum;
	}

	public static int Sum (int a, int b) {
		return a + b;
	}

	public static int SumOfDigit (int a, int b) {
		return SumOfDigit(a) + SumOfDigit(b);
	}

	public static int Multiply (int a, int b ) {
		return a * b;
	}

	public static int AbsSubstraction (int a, int b) {
		return Math.Abs (a - b);
	}
		
	public static int AModB (int a, int b) {
		return a % b;
	}

	public static int BModA (int a, int b) {
		return b % a;
	}

	public static int ModofSum (int a, int b) {
		return (a + b) % 2;
	}

	public static int Largest (int a, int b) {
		return Mathf.Max (a, b);
	}

	public static int Smallest (int a, int b) {
		return Mathf.Min (a, b);
	}

	public static int AIsLarger (int a, int b) {
		if (a > b)
			return 1;
		return 0;
	}

	public static int BIsLarger (int a, int b) {
		if (b > a)
			return 1;
		return 0;
	}
}
