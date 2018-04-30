using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ManagerScene: MonoBehaviour {

	//void Awake(){
	//	if (!exist) {
	//		DontDestroyOnLoad (this.gameObject);
	//		exist = true;
	//	} else {
	//		Destroy (this.gameObject);
	//	}
	//}

	[SerializeField] bool enableBackToTitle;
	[SerializeField] bool enableExitApp;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && enableBackToTitle) {
			LoadMainMenu ();
		}
		else if(Input.GetKeyDown (KeyCode.Escape) && enableExitApp) {
			Application.Quit ();
		}

	}

	public void LoadMainMenu() {
		SceneManager.LoadScene (0);
	}

	public void LoadSurvivalMode() {
		SceneManager.LoadScene (1);
		//SceneManager.LoadScene(SurvivalModeScene.name);
	}

	public void LoadBaghdadOP() {
		SceneManager.LoadScene (2);
	}

	public void LoadBaghdadStoryScene() {
		SceneManager.LoadScene (3);
	}

	public void LoadBaghdadPlay() {
		SceneManager.LoadScene (4);
	}

	public void LoadBaghdadAnswer() {
		GameObject.Find ("Manager").GetComponent<ChallengeController> ().SaveRealAnswer();
		SceneManager.LoadScene (5);
	}

	public void BaghdadToNextStageAnswer() {
		//check button cue from numpadscript... strange, i know
		if (GameObject.Find ("AngkaA").GetComponent<NumpadScript> ().IsToNextStageEnabled ()) {
			//check if answer is true or false
			if (GameObject.Find ("AngkaA").GetComponent<NumpadScript> ().IsRightAnswer ()) {
				SceneManager.LoadScene (7);
			} else {
				SceneManager.LoadScene (6);
			}
		}

	}


}