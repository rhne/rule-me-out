using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera.main.aspect = 720f / 1280f;
		int ratio = Screen.height / 1280;
		Screen.SetResolution ( 405, 720, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
