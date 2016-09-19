using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HistoryList : MonoBehaviour {
	public GameObject attemptEntryPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Append() {
		GameObject go = (GameObject)Instantiate (attemptEntryPrefab);
		go.transform.SetParent (this.transform, false);
	}

	public void Append(int A, int B, int R) {
		GameObject go = (GameObject)Instantiate (attemptEntryPrefab);
		go.transform.SetParent (this.transform, false);
		Debug.Log ("this is append function");

		go.transform.Find ("A").GetComponent<Text> ().text = A.ToString();
		go.transform.Find ("B").GetComponent<Text> ().text = B.ToString();
		go.transform.Find ("R").GetComponent<Text> ().text = R.ToString();

	}

}
